using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TimeKeeper.Api.Data;
using TimeKeeper.Shared.Api.Features.Client;

namespace TimeKeeper.Api.Features.Client
{
    public class GetActiveHandler : IRequestHandler<GetActive.Query, IEnumerable<GetActive.Model>>
    {
        private readonly TimeKeeperContext _context;

        public GetActiveHandler(TimeKeeperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetActive.Model>> Handle(GetActive.Query request, CancellationToken cancellationToken)
        {
            var clients = await _context.Clients.Where(x => x.IsActive).OrderBy(x => x.Name).ToListAsync(cancellationToken: cancellationToken);

            return clients.Select(x => new GetActive.Model
            {
                Id = x.Id,
                Name = x.Name
            });
        }
    }
}
