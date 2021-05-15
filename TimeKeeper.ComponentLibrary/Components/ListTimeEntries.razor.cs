// using Microsoft.AspNetCore.Components;
// using System;
// using System.Collections.Generic;
// using TimeKeeper.Domain.Models;
//
// namespace TimeKeeper.ComponentLibrary.Components
// {
//     public partial class ListTimeEntries
//     {
//         [Parameter] public IEnumerable<TimeEntry> TimeEntries { get; set; }
//         [Parameter] public DateTime SelectedDate { get; set; }
//
//         protected string GetClientName(int id)
//         {
//             switch (id)
//             {
//                 case 1:
//                     return "Amazon";                    
//                 case 2:
//                     return "Microsoft";
//                 case 3:
//                     return "Google";
//                 case 4:
//                     return "Twitter";
//                 case 5:
//                     return "Facebook";
//                 default:
//                     return "Other";
//             }
//         }
//
//         protected string GetCategoryName(int id)
//         {
//             switch (id)
//             {
//                 case 1:
//                     return "Meeting";
//                 case 2:
//                     return "Call";
//                 case 3:
//                     return "Documentation";
//                 case 4:
//                     return "Travel";
//                 default:
//                     return "Other";
//             }
//         }
//     }
// }
