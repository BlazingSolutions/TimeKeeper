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

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var isDeleted = await _timeEntryRepository.DeleteByIdAsync(id);

                return isDeleted ? Ok() : BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_timeEntryRepository.GetByIdAsync(id));
        }

        [HttpGet("GetForUserOnSelectedDate")]
        public IActionResult GetForUserOnSelectedDate(int userId, DateTime selectedDate)
        {
            return Ok(_timeEntryRepository.GetForUserOnSelectedDateAsync(userId, selectedDate));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TimeEntry timeEntry)
        {
            if (timeEntry == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TimeEntry timeEntryToUpdate = await _timeEntryRepository.GetByIdAsync(timeEntry.Id);

            if (timeEntryToUpdate == null)
            {
                return NotFound();
            }

            await _timeEntryRepository.UpdateAsync(timeEntry);

            return NoContent(); //success
        }
    }
}
