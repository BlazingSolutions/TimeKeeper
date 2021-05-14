using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;
using TimeKeeper.Repository;

namespace TimeKeeper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionalOfficeController : ControllerBase
    {
        private readonly IRegionalOfficeRepository _regionalOfficeRepository;

        public RegionalOfficeController(IRegionalOfficeRepository regionalOfficeRepository)
        {
            _regionalOfficeRepository = regionalOfficeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegionalOffice regionalOffice)
        {
            if (regionalOffice == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            regionalOffice = await _regionalOfficeRepository.CreateAsync(regionalOffice);

            return Created("regionalOffice", regionalOffice);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var isDeleted = await _regionalOfficeRepository.DeleteByIdAsync(id);

                return isDeleted ? Ok() : BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<RegionalOffice> list = await _regionalOfficeRepository.GetAllAsync();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_regionalOfficeRepository.GetByIdAsync(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RegionalOffice regionalOffice)
        {
            if (regionalOffice == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RegionalOffice regionalOfficeToUpdate = await _regionalOfficeRepository.GetByIdAsync(regionalOffice.Id);

            if (regionalOfficeToUpdate == null)
            {
                return NotFound();
            }

            await _regionalOfficeRepository.UpdateAsync(regionalOffice);

            return NoContent(); //success
        }
    }
}
