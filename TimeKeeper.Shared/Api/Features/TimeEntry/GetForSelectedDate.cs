using System;

namespace TimeKeeper.Shared.Api.Features.TimeEntry
{
    public class GetForSelectedDate
    {
        public record Model
        {
            public string CategoryName { get; set; }
            public string ClientName { get; set; }
            public decimal Hours { get; set; }
            public string Notes { get; set; }
            public int Id { get; set; }
        }
    }
}