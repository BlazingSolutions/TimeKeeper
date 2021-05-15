using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Threading.Tasks;
using Example.Api.Client.CSharp.Contracts;

namespace TimeKeeper.ComponentLibrary.Components
{
    public partial class AddTimeEntry
    { [Inject] protected ITimeEntryClient TimeEntryClient { get; set; }

        [Parameter] public EventCallback<string> OnClick { get; set; }

        protected Command Command { get; set; }

        protected override void OnParametersSet()
        {
            //TODO this will be replaced with actual user id once authentication has been implemented.
            var userId = 1;

            Command = new Command
            {
                UserId = userId
            };
        }

        protected async Task SaveAsync()
        {
            await TimeEntryClient.CreateAsync(Command);
            await OnClick.InvokeAsync("SubmitTimeEntry");
        }

        protected async Task CancelAsync()
        {
            await OnClick.InvokeAsync("CancelTimeEntry");
        }
    }
}