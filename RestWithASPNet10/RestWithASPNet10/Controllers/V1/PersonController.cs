using Microsoft.AspNetCore.Mvc;
using RestWithASPNet10.Data.DTO.V1;
using RestWithASPNet10.Services;

namespace RestWithASPNet10.Controllers.V1
{
    [Route("api/[controller]/v1")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonServices _personServices;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonServices personServices, ILogger<PersonController> logger)
        {
            _personServices = personServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting all people");

            return Ok(_personServices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Getting person with id {Id}", id);

            var person = _personServices.FindById(id);

            if(person == null)
            {
                _logger.LogWarning("Person with id {Id} not found", id);
                return NotFound();
            }
            else
            {
                return Ok(person);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonDTO person)
        {
            _logger.LogInformation("Creating a new person: {firstName}", person.FirstName);
            var createdPerson = _personServices.Create(person);

            if(createdPerson == null)
            {
                _logger.LogError("Failed to create person: {firstName}", person.FirstName);
                return BadRequest();
            }
            Response.Headers.Add("X-API-Deprecated", "true"); 
            Response.Headers.Add("X-API-Deprecation-Date", "2026-12-31");
            return Ok(person);
        }

        [HttpPut]
        public IActionResult Put(PersonDTO person)
        {
            _logger.LogInformation("Updating person with id {Id}", person.Id);
             
            var createdPerson = _personServices.Update(person);

            if(createdPerson == null)
            {
                _logger.LogError("Failed to update person with id {Id}", person.Id);
                return BadRequest();
            }

            _logger.LogDebug("Person with id {Id} updated successfully", person.Id);

            return Ok(person);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var person = _personServices.FindById(id);

            if (person == null)
            {
                _logger.LogError("Failed to delete person with id {Id}", id);
                return NotFound();
            }

            _logger.LogInformation("Deleting person with id {Id}", id);
            _personServices.Delete(id);

            _logger.LogDebug("Person with id {Id} deleted successfully", id);
            return NoContent();
        }
    }
}
