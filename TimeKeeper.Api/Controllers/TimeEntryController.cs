using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using TimeKeeper.Api.Features.TimeEntry;

namespace TimeKeeper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TimeEntryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateTimeEntry.Command command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _mediator.Send(command));
        }

        [HttpGet("GetForSelectedDate")]
        public async Task<ActionResult<IEnumerable<GetForSelectedDate.Model>>> GetForSelectedDate([FromQuery]GetForSelectedDate.Query query)
        {
            var results = await _mediator.Send(query);
            return Ok(results);
        }
    }
}
