using System.Linq;
using System.Threading;
using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using TimeKeeper.Api.Data;
using TimeKeeper.Shared.Api.Features.Category;

namespace TimeKeeper.Api.Features.Category
{
    public class CategoryModule : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/Category/GetActive", async (
                [FromServices] TimeKeeperContext context) =>
            {
                var categories = await context.Categories
                    .Where(x => x.IsActive)
                    .OrderBy(x => x.Name)
                    .ToListAsync();

                return categories.Select(x => new GetActive.Model
                {
                    Id = x.Id,
                    Name = x.Name
                });
            });
        }
    }
}