using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Repository
{
    public interface ITimeEntryRepository
    {        
        Task<TimeEntry> CreateAsync(TimeEntry timeEntry);                
        Task<IEnumerable<TimeEntry>> GetForSelectedDateAsync(int userId, DateTime selectedDate);        
    }
}