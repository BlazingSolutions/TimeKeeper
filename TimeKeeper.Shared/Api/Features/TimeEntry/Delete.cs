using MediatR;

namespace TimeKeeper.Shared.Api.Features.TimeEntry
{
    public class Delete
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }
    }
}