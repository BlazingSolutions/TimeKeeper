using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using TimeKeeper.Shared.Api.Features.TimeEntry;

namespace TimeKeeper.Shared.Api
{
    public interface ITimeEntryApi
    {        
        [Get("/api/Category/GetActive")]        
        Task<IEnumerable<Features.Category.GetActive.Model>> GetActive(Features.Category.GetActive.Query query);

        [Get("/api/Client/GetActive")]
        Task<IEnumerable<Features.Client.GetActive.Model>> GetActive(Features.Client.GetActive.Query query);

        [Get("/api/TimeEntry/GetForSelectedDate")]
        Task<IEnumerable<GetForSelectedDate.Model>> GetForSelectedDate(GetForSelectedDate.Query query);

        [Post("/api/TimeEntry")]
        Task<int> Create(Create.Command command);

        [Delete("/api/TimeEntry")]
        Task Delete(Delete.Command command);        
    }
}