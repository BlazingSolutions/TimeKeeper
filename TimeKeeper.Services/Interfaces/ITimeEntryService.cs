using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Services
{
    public interface ITimeEntryService
    {
        Task<bool> DeleteByIdAsync(int id);
        Task<TimeEntry> CreateAsync(TimeEntry timeEntry);
        Task<IEnumerable<TimeEntriesView>> GetForUserOnSelectedDateAsync(int userId, DateTime selectedDate);
        Task<TimeEntry> GetByIdAsync(int id);                
        Task<TimeEntry> UpdateAsync(TimeEntry timeEntry);
    }
}