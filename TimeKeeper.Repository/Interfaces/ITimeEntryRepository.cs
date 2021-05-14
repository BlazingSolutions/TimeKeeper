using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Repository
{
    public interface ITimeEntryRepository
    {        
        Task<TimeEntry> CreateAsync(TimeEntry timeEntry);
        Task<bool> DeleteByIdAsync(int id);
        Task<TimeEntry> GetByIdAsync(int id);
        IEnumerable<TimeEntriesView> GetForUserOnSelectedDateAsync(int userId, DateTime selectedDate);
        Task<TimeEntry> UpdateAsync(TimeEntry timeEntry);
    }
}