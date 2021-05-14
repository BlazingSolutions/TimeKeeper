using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;
using TimeKeeper.Repository;

namespace TimeKeeper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            category = await _categoryRepository.CreateAsync(category);

            return Created("category", category);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var isDeleted = await _categoryRepository.DeleteByIdAsync(id);

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
            List<Category> list = await _categoryRepository.GetAllAsync();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_categoryRepository.GetByIdAsync(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Category categoryToUpdate = await _categoryRepository.GetByIdAsync(category.Id);

            if (categoryToUpdate == null)
            {
                return NotFound();
            }

            await _categoryRepository.UpdateAsync(category);

            return NoContent(); //success
        }
    }
}
