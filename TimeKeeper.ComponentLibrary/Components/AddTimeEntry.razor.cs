using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Threading.Tasks;
using TimeKeeper.ComponentLibrary.Api;
using TimeKeeper.ComponentLibrary.Api.Features.TimeEntry;

namespace TimeKeeper.ComponentLibrary.Components
{
    public partial class AddTimeEntry
    { [Inject] protected ITimeEntryApi TimeEntryApi { get; set; }

        [Parameter] public EventCallback<string> OnClick { get; set; }

        protected CreateTimeEntry.Command Command { get; set; }

        protected override void OnParametersSet()
        {
            //TODO this will be replaced with actual user id once authentication has been implemented.
            var userId = 1;

            Command = new CreateTimeEntry.Command
            {
                UserId = userId
            };
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