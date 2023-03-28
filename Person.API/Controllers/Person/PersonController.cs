using Application.Person.Dtos;
using Application.Person.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Person.API.Controllers.Person
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonHandler _personHandler;

        public PersonController(IPersonHandler personHandler)
        {
            _personHandler = personHandler;
        }

        [HttpGet("GetPersons")]
        public async Task<IActionResult> GetPesons(int top = 50)
        {
            return Ok(await _personHandler.Get(top));
        }

        [HttpGet("{id:int}", Name = "GetById")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var entities = await _personHandler.Get(id);
            if (entities == null)
            {
                return NotFound();
            }
            return Ok(entities);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonRequestDto person)
        {
            try
            {
                var Entity = await _personHandler.Create(person);
                return Ok(Entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PersonRequestDto dto)
        {
            try
            {
                var Entity = await _personHandler.Update(id, dto);
                return Ok(Entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }
    }
}
