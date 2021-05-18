using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TimeKeeper.Api.Data;
using TimeKeeper.Shared.Api.Features.TimeEntry;

namespace TimeKeeper.Api.Features.TimeEntry
{
    public class CreateTimeEntryHandler : IRequestHandler<CreateTimeEntry.Command, int>
    {
        private readonly TimeKeeperContext _context;

        public CreateTimeEntryHandler(TimeKeeperContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTimeEntry.Command command, CancellationToken cancellationToken)
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