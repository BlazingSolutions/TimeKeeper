using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;
using TimeKeeper.Services;

namespace TimeKeeper.ComponentLibrary.Components
{
    public partial class AddTimeEntry
    {        
        [Inject] protected ITimeEntryService TimeEntryService { get; set; }

        [Parameter] public EventCallback<string> OnClick { get; set; }        

        protected TimeEntry TimeEntry { get; set; }

        MudSelect<int> ClientSelect;

        protected override void OnParametersSet()
        {
            //TODO this will be replaced with actual user id once authentication has been implemented.
            var userId = 1;
            
            TimeEntry = new TimeEntry
            {
                User = userId,
                CreatedBy = userId
            };
        }

        protected async Task SaveAsync()
        {
            await TimeEntryService.CreateAsync(TimeEntry);

            await OnClick.InvokeAsync("SubmitTimeEntry");
        }

        protected async Task CancelAsync()
        {            
            await OnClick.InvokeAsync("CancelTimeEntry");
        }
    }
}
