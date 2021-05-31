using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using TimeKeeper.Shared.Api.Features.Category;

namespace TimeKeeper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }        

        [HttpGet("GetActive")]
        public async Task<ActionResult<IEnumerable<GetActive.Model>>> GetActive([FromQuery] GetActive.Query query)
        {
            var results = await _mediator.Send(query);
            return Ok(results);
        }
    }
}