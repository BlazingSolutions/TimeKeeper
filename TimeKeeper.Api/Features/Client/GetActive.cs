using System.Linq;
using System.Threading;
using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using TimeKeeper.Api.Data;
using TimeKeeper.Shared.Api.Features.Client;

namespace TimeKeeper.Api.Features.Client
{
    public class ClientModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/Client/GetActive",
                async (
                    [FromServices] TimeKeeperContext context,
                    CancellationToken cancellationToken) =>
                {
                    var clients = await context.Clients.Where(x => x.IsActive).OrderBy(x => x.Name)
                        .ToListAsync(cancellationToken: cancellationToken);

                    return clients.Select(x => new GetActive.Model
                    {
                        Id = x.Id,
                        Name = x.Name
                    });
                });
        }
    }
}