using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;

namespace TimeKeeper.Api.Features.TimeEntry
{
    public class GetForSelectedDate
    {
        public record Query : IRequest<IEnumerable<Model>>
        {
            public int UserId { get; set; }
            public DateTime SelectedDate { get; set; }
        }

        public class Model
        {
            public int Category { get; set; }
            public int Client { get; set; }
            public decimal Hours { get; set; }
            public string Notes { get; set; }
        }
        
        public class Handler : IRequestHandler<Query, IEnumerable<Model>>
        {
            private readonly SqlConnection _dbConnection;

            public Handler(SqlConnection dbConnection)
            {
                _dbConnection = dbConnection;
            }

            public async Task<IEnumerable<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                string sql = "SELECT * FROM TimeEntries " +
                             "WHERE [User] = @UserId AND CAST(DateCreated As date) = CAST(@selectedDate As date) " +
                             "ORDER BY DateCreated DESC";

                IEnumerable<Domain.TimeEntry> timeEntries =
                    await _dbConnection.QueryAsync<Domain.TimeEntry>(sql,
                        new
                        {
                            UserId = request.UserId,
                            SelectedDate = request.SelectedDate
                        });

                return timeEntries.Select(x=>new Model
                {
                    Category = x.Category,
                    Client = x.Client,
                    Hours = x.Hours,
                    Notes = x.Notes
                });
            }
        }
    }
}