using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeKeeper.Domain.Models;
using TimeKeeper.Repository;

namespace TimeKeeper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            client = await _clientRepository.CreateAsync(client);

            return Created("client", client);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var isDeleted = await _clientRepository.DeleteByIdAsync(id);

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
            List<Client> list = await _clientRepository.GetAllAsync();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_clientRepository.GetByIdAsync(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Client client)
        {
            if (client == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Client clientToUpdate = await _clientRepository.GetByIdAsync(client.Id);

            if (clientToUpdate == null)
            {
                return NotFound();
            }

            await _clientRepository.UpdateAsync(client);

            return NoContent(); //success
        }
    }
}
