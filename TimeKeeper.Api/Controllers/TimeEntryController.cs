using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;
using TimeKeeper.Repository;

namespace TimeKeeper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntryController : ControllerBase
    {
        private readonly ITimeEntryRepository _timeEntryRepository;

        public TimeEntryController(ITimeEntryRepository timeEntryRepository)
        {
            _timeEntryRepository = timeEntryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TimeEntry timeEntry)
        {
            if (timeEntry == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            timeEntry = await _timeEntryRepository.CreateAsync(timeEntry);

            return Created("timeEntry", timeEntry);
        }

        [HttpGet("GetForSelectedDate")]
        public IActionResult GetForSelectedDate(int userId, DateTime selectedDate)
        {
            return Ok(_timeEntryRepository.GetForSelectedDateAsync(userId, selectedDate));
        }
    }
}
