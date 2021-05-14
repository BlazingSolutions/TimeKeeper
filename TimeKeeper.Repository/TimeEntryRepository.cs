using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Repository
{
    public class TimeEntryRepository : ITimeEntryRepository
    {
        private readonly TimeKeeperContext _context;
        private readonly IDbConnection _dbConnection;

        public TimeEntryRepository(TimeKeeperContext context, string connectionString)
        {
            _context = context;
            _dbConnection = new SqlConnection(connectionString);
        }

        public async Task<TimeEntry> CreateAsync(TimeEntry timeEntry)
        {
            timeEntry.DateCreated = DateTime.Now;
            timeEntry.IsSubmitted = false;
            timeEntry.IsAuthorised = false;

            _context.TimeEntries.Add(timeEntry);

            await _context.SaveChangesAsync();

            return timeEntry;
        }        

        public IEnumerable<TimeEntry> GetForSelectedDateAsync(int userId, DateTime selectedDate)
        {
            string sql = "SELECT * FROM TimeEntries " +
                "WHERE [User] = @UserId AND CAST(DateCreated As date) = CAST(@selectedDate As date) " +
                "ORDER BY DateCreated DESC";

            IEnumerable<TimeEntry> timeEntries = _dbConnection.Query<TimeEntry>(sql,
                new
                {
                    UserId = userId,
                    SelectedDate = selectedDate
                });

            return timeEntries;
        }
    }
}
