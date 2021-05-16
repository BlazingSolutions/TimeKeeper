using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using TimeKeeper.ComponentLibrary.Api.Features.TimeEntry;

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

            return timeEntries.Select(x => new GetForSelectedDate.Model
            {
                Category = x.Category,
                Client = x.Client,
                Hours = x.Hours,
                Notes = x.Notes
            });
        }
    }
}