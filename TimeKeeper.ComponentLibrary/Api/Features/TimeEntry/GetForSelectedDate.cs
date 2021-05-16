using System;
using System.Collections.Generic;
using MediatR;

namespace TimeKeeper.ComponentLibrary.Api.Features.TimeEntry
{
    public class GetForSelectedDate
    {
        public record Query : IRequest<IEnumerable<Model>>
        {
            public int UserId { get; set; }
            public DateTime SelectedDate { get; set; }
        }

        public record Model
        {
            public int Category { get; set; }
            public int Client { get; set; }
            public decimal Hours { get; set; }
            public string Notes { get; set; }
        }
    }
}