using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using TimeKeeper.ComponentLibrary.Api.Features.TimeEntry;

namespace TimeKeeper.ComponentLibrary.Api
{
    public interface ITimeEntryApi
    {
        [Get("/api/TimeEntry/GetForSelectedDate")]
        Task<IEnumerable<GetForSelectedDate.Model>> GetForSelectedDate(int userId, DateTime selectedDate);

        [Post("/api/TimeEntry")]
        Task<int> Create(CreateTimeEntry.Command command);
    }
}