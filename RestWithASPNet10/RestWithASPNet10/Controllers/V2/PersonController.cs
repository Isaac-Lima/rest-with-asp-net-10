using Microsoft.AspNetCore.Mvc;
using RestWithASPNet10.Data.DTO.V2;
using RestWithASPNet10.Services.Impl;

namespace RestWithASPNet10.Controllers.V2
{
    [Route("api/[controller]/v2")]
    [ApiController]
    public class PersonControllerV2 : ControllerBase
    {
        private readonly PersonServicesImplV2 _personServices;
        private readonly ILogger<PersonControllerV2> _logger;

        public PersonControllerV2(PersonServicesImplV2 personServices, ILogger<PersonControllerV2> logger)
        {
            _personServices = personServices;
            _logger = logger;
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

            return Ok(person);
        }
    }
}
