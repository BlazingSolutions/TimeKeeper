using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TimeKeeper.Shared.Api;
using TimeKeeper.Shared.Api.Features.TimeEntry;

namespace TimeKeeper.Shared.Components
{
    public partial class AddTimeEntry
    {        
        [Inject] protected ITimeEntryApi TimeEntryApi { get; set; }


        [Parameter] public EventCallback<string> OnClick { get; set; }

        protected Create.Command Command { get; set; }

        protected IEnumerable<Api.Features.Category.GetActive.Model> Categories { get; set; }

        protected IEnumerable<Api.Features.Client.GetActive.Model> Clients { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            //TODO this will be replaced with actual user id once authentication has been implemented.
            var userId = 1;

            Command = new Create.Command
            {
                UserId = userId
            };            

            Categories = await TimeEntryApi.GetActiveCategories();
            Clients = await TimeEntryApi.GetActiveClients();
        }

        protected async Task SaveAsync()
        {
            await TimeEntryApi.Create(Command);
            await OnClick.InvokeAsync("SubmitTimeEntry");
        }

        protected async Task CancelAsync()
        {
            await OnClick.InvokeAsync("CancelTimeEntry");
        }
    }
}