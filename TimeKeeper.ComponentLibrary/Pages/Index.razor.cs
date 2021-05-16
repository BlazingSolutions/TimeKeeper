using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeKeeper.ComponentLibrary.Api;
using TimeKeeper.ComponentLibrary.Api.Features.TimeEntry;

namespace TimeKeeper.ComponentLibrary.Pages
{
    public partial class Index
    {
        [Inject] protected ITimeEntryApi TimeEntryApi { get; set; }
        
        protected DateTime SelectedDate { get; set; }

        protected IEnumerable<GetForSelectedDate.Model> TimeEntries { get; set; }

        protected bool DisplayAddEntry { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            SelectedDate = DateTime.Today;
            
            await GetTimeEntriesAsync();
        }

        private async Task GetTimeEntriesAsync()
        {
            //TODO this will be replaced with actual user id once authentication has been implemented.
            var userId = 1;

            TimeEntries = await TimeEntryApi.GetForSelectedDate(userId, SelectedDate);

            DisplayAddEntry = TimeEntries.Any() == false;
        }

        protected void AddNewTimeEntry()
        {
            DisplayAddEntry = true;
        }

        public async Task SubmitActionAsync(string action)
        {            
            switch (action)
            {
                case "SubmitTimeEntry":
                    await GetTimeEntriesAsync();
                    break;
                default:
                    DisplayAddEntry = false;
                    break;
            }
        }
    }
}
