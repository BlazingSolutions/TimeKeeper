using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Carter;
using Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Data.SqlClient;
using TimeKeeper.Shared.Api.Features.TimeEntry;

namespace TimeKeeper.Api.Features.TimeEntry
{
    public class ListByDate : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/TimeEntry/GetForSelectedDate", async (
                int userId,
                DateTime selectedDate,
                [FromServices] SqlConnection dbConnection) =>
            {
                var sql =
                    "SELECT TimeEntries.Id, TimeEntries.Hours, TimeEntries.Notes, Categories.Name As CategoryName, Clients.Name As ClientName " +
                    "FROM TimeEntries " +
                    "INNER JOIN Categories ON Categories.Id = Category " +
                    "INNER JOIN Clients ON Clients.Id = Client " +
                    "WHERE [User] = @UserId AND CAST(TimeEntries.DateCreated As date) = CAST(@selectedDate As date) " +
                    "ORDER BY TimeEntries.DateCreated DESC";
                
                return await dbConnection.QueryAsync<GetForSelectedDate.Model>(sql,
                    new
                    {
                        userId,
                        selectedDate
                    });
            });
        }
    }
}