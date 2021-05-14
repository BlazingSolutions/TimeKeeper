using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;
using TimeKeeper.Services;

namespace TimeKeeper.ComponentLibrary.Pages
{
    public partial class Index
    {
        [Inject] protected ITimeEntryService TimeEntryService { get; set; }

        protected User CurrentUser { get; set; }

        protected DateTime SelectedDate { get; set; }

        protected IEnumerable<TimeEntriesView> TimeEntries { get; set; }

        protected bool DisplayAddEntry { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            //TODO Remove below and replace with actual user
            CurrentUser = new();
            CurrentUser.Id = 1;

            SelectedDate = DateTime.Today;
            
            await GetTimeEntriesAsync();
        }

        private async Task GetTimeEntriesAsync()
        {
            TimeEntries = await TimeEntryService.GetForUserOnSelectedDateAsync(1, SelectedDate);

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
