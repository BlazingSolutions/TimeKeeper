using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeKeeper.Api.Data;
using TimeKeeper.Shared.Api.Features.TimeEntry;

namespace TimeKeeper.Api.Features.TimeEntry
{
    public class DeleteHandler : IRequestHandler<Delete.Command, int>
    {
        private readonly TimeKeeperContext _context;

        public DeleteHandler(TimeKeeperContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(Delete.Command command, CancellationToken cancellationToken)
        {
            var timeEntry = await _context.TimeEntries.Where(x => x.Id == command.Id).FirstOrDefaultAsync();

            if (timeEntry == null) return default;            

            _context.TimeEntries.Remove(timeEntry);

            await _context.SaveChangesAsync(cancellationToken);

            return timeEntry.Id;
        }
    }
}
