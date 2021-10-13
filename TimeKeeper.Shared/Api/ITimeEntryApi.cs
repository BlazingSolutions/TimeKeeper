using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using TimeKeeper.Shared.Api.Features.TimeEntry;

namespace TimeKeeper.Shared.Api
{
    public interface ITimeEntryApi
    {        
        [Get("/api/Category/GetActive")]        
        Task<IEnumerable<Features.Category.GetActive.Model>> GetActiveCategories();

        [Get("/api/Client/GetActive")]
        Task<IEnumerable<Features.Client.GetActive.Model>> GetActiveClients();

        [Get("/api/TimeEntry/GetForSelectedDate")]
        Task<IEnumerable<GetForSelectedDate.Model>> GetForSelectedDate( int userId, DateTime selectedDate);

        [Post("/api/TimeEntry")]
        Task<int> Create(Create.Command command);

        [Delete("/api/TimeEntry/{command.id}")]
        Task Delete(Delete.Command command);        
    }
}