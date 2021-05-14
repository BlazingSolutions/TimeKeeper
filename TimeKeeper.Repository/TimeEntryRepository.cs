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

        public async Task<TimeEntry> GetByIdAsync(int id)
        {
            return await _context.TimeEntries.FindAsync(id);
        }

        public IEnumerable<TimeEntriesView> GetForUserOnSelectedDateAsync(int userId, DateTime selectedDate)
        {
            string sql = "SELECT * FROM TimeEntriesView " +
                "WHERE [User] = @UserId AND CAST(DateCreated As date) = CAST(@selectedDate As date) " +
                "ORDER BY DateCreated DESC";

            IEnumerable<TimeEntriesView> timeEntries = _dbConnection.Query<TimeEntriesView>(sql,
                new
                {
                    UserId = userId,
                    SelectedDate = selectedDate
                });

            return timeEntries;
        }

        public async Task<TimeEntry> UpdateAsync(TimeEntry timeEntry)
        {
            timeEntry.DateModified = DateTime.Now;

            _context.TimeEntries.Add(timeEntry);

            await _context.SaveChangesAsync();

            return timeEntry;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            TimeEntry timeEntry = await GetByIdAsync(id);

            if (timeEntry is null)
            {
                return false;
            }

            _context.TimeEntries.Remove(timeEntry);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
