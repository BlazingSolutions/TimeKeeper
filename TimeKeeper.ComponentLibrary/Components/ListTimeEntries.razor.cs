using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using TimeKeeper.Domain.Models;

namespace TimeKeeper.ComponentLibrary.Components
{
    public partial class ListTimeEntries
    {
        [Parameter] public IEnumerable<TimeEntriesView> TimeEntries { get; set; }
        [Parameter] public DateTime SelectedDate { get; set; }
    }
}
