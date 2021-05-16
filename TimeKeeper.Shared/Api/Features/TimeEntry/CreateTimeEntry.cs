using MediatR;

namespace TimeKeeper.Shared.Api.Features.TimeEntry
{
    public class CreateTimeEntry
    {
        // validator could also go here (and could be used in both clients + the API
        // for fast feedback on client + reliable validation on the server)
    
        public record Command : IRequest<int>
        {
            public int Category { get; set; }
            public int Client { get; set; }
            public decimal Hours { get; set; }
            public string Notes { get; set; }
            public int UserId { get; set; }
        }
    }
}