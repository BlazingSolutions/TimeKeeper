using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using TimeKeeper.Shared.Api.Features.TimeEntry;

namespace TimeKeeper.Api.Features.TimeEntry
{
    public class
        GetForSelectedDateHandler : IRequestHandler<GetForSelectedDate.Query, IEnumerable<GetForSelectedDate.Model>>
    {
        private readonly SqlConnection _dbConnection;

        public GetForSelectedDateHandler(SqlConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<GetForSelectedDate.Model>> Handle(GetForSelectedDate.Query request,
            CancellationToken cancellationToken)
        {
            string sql = "SELECT TimeEntries.Id, TimeEntries.Hours, TimeEntries.Notes, Categories.Name As CategoryName, Clients.Name As ClientName " +
                "FROM TimeEntries " +
                "INNER JOIN Categories ON Categories.Id = Category " +
                "INNER JOIN Clients ON Clients.Id = Client " +
                "WHERE [User] = @UserId AND CAST(TimeEntries.DateCreated As date) = CAST(@selectedDate As date) " +
                "ORDER BY TimeEntries.DateCreated DESC";

            return await _dbConnection.QueryAsync<GetForSelectedDate.Model>(sql,
                new
                {
                    request.UserId,
                    request.SelectedDate
                });
        }
    }
}