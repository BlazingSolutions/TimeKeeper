using System;
using System.Threading;
using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using TimeKeeper.Api.Data;
using TimeKeeper.Shared.Api.Features.TimeEntry;

namespace TimeKeeper.Api.Features.TimeEntry
{
    public class CreateEntry : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("api/TimeEntry", async (
                    [FromServices] TimeKeeperContext context, 
                    [FromBody] Create.Command command,
                    CancellationToken cancellationToken)
                =>
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

                context.TimeEntries.Add(timeEntry);
                await context.SaveChangesAsync(cancellationToken);
                return timeEntry.Id;
            });
        }
    }
}