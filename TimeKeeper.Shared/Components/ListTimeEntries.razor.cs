using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using TimeKeeper.Shared.Api.Features.TimeEntry;
using System.Threading.Tasks;

namespace TimeKeeper.Shared.Components
{
    public partial class ListTimeEntries
    {
        [Parameter] public IEnumerable<GetForSelectedDate.Model> TimeEntries { get; set; }
        [Parameter] public DateTime SelectedDate { get; set; }
        [Parameter] public EventCallback<int> OnDeleted { get; set; }        

        private Task Delete(int id)
        {
            return OnDeleted.InvokeAsync(id);
        }
    }
}