using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.Services
{
    public interface ITimeEntryService
    {        
        Task<TimeEntry> CreateAsync(TimeEntry timeEntry);
        Task<IEnumerable<TimeEntry>> GetForSelectedDateAsync(int userId, DateTime selectedDate);        
    }
}