using Microsoft.AspNetCore.Mvc;
using WA1.Application.Services.PersonService;
using WA1.Domain.Entities;

namespace WA1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        [Route("api/GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var person = _personService.GetbyId(id);
            if(person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        [Route("api/Create")]
        public IActionResult Create(Person person)
        {
            _personService.AddAsync(person);
            return CreatedAtAction(nameof(GetById), new {id = person.Id}, person);
        }


        [HttpPut]
        [Route("api/Update/{id}")]
        public IActionResult Update(int id, Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            var foundPerson = _personService.GetbyId(id);
            if (foundPerson == null) 
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("api/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var personToDelete = _personService.GetbyId(id);
            if(personToDelete == null)
            {
                return NotFound();
            }
            _personService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet]
        [Route("api/GetAll")]
        public IActionResult GetAllPeople()
        {
            var people = _personService.GetAllPeopleAsync();
            return Ok(people);
        }

    }
}
