using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TimeKeeper.Api.Data;

namespace TimeKeeper.Api.Features.TimeEntry
{
    public record CreateTimeEntry
    {
        public class Command : IRequest<int>
        {
            public int Category { get; set; }
            public int Client { get; set; }
            public decimal Hours { get; set; }
            public string Notes { get; set; }
            public int UserId { get; set; }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly TimeKeeperContext _context;

            public Handler(TimeKeeperContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(Command command, CancellationToken cancellationToken)
            {
                var timeEntry = new Domain.TimeEntry
                {
                    Hours = command.Hours,
                    Category = command.Category,
                    Client = command.Client,
                    Notes = command.Notes,
                    DateCreated = DateTime.Now, 
                    IsSubmitted = false, 
                    IsAuthorised = false,
                    CreatedBy = command.UserId,
                    User = command.UserId
                };

                _context.TimeEntries.Add(timeEntry);

                await _context.SaveChangesAsync(cancellationToken);

                return timeEntry.Id;
            }
        }
    }
}