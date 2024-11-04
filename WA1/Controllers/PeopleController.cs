using Microsoft.AspNetCore.Mvc;
using WA1.Application.Services.PersonService;

namespace WA1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;


        [HttpPut]
        [Route("api/person/update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id)
        {

        }


    }
}
