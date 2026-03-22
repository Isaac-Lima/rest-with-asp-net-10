using Microsoft.AspNetCore.Mvc;
using RestWithASPNet10.Data.DTO.V2;
using RestWithASPNet10.Services.Impl;

namespace RestWithASPNet10.Controllers.V2
{
    [Route("api/[controller]/v2")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonServicesImplV2 _personServices;
        private readonly ILogger<PersonController> _logger;

        public PersonController(PersonServicesImplV2 personServices, ILogger<PersonController> logger)
        {
            _personServices = personServices;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(PersonDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] PersonDTO person)
        {
            _logger.LogInformation("Creating a new person: {firstName}", person.FirstName);
            var createdPerson = _personServices.Create(person);

            if(createdPerson == null)
            {
                _logger.LogError("Failed to create person: {firstName}", person.FirstName);
                return BadRequest();
            }

            //createdPerson.LastName = null;
            //createdPerson.Age = 0;
            //createdPerson.Age = 20;
            return Ok(createdPerson);
        }
    }
}
