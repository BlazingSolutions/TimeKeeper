using System.Linq;
using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using TimeKeeper.Api.Data;

namespace TimeKeeper.Api.Features.TimeEntry
{
    public class DeleteEntry : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/api/TimeEntry/{id:int}", async (
                int id, 
                TimeKeeperContext context) =>
            {
                var timeEntry = await context.TimeEntries
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();

                if (timeEntry == null)
                    return Results.NotFound();

                context.TimeEntries.Remove(timeEntry);

                await context.SaveChangesAsync();

                return Results.Ok(timeEntry.Id);
            });
        }
    }
}