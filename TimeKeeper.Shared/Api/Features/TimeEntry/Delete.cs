using MediatR;

namespace TimeKeeper.Shared.Api.Features.TimeEntry
{
    public class Delete
    {
        public class Command : IRequest<int>
        {
            public int Id { get; set; }
        }
    }
}