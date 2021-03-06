using System;
using System.Collections.Generic;
using MediatR;

namespace TimeKeeper.Shared.Api.Features.TimeEntry
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
            public string CategoryName { get; set; }
            public string ClientName { get; set; }
            public decimal Hours { get; set; }
            public string Notes { get; set; }
            public int Id { get; set; }
        }
    }
}