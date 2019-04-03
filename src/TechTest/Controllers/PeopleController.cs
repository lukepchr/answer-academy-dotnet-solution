using System;
using Microsoft.AspNetCore.Mvc;
using TechTest.Repositories;
using TechTest.Repositories.Models;

namespace TechTest.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        public PeopleController(IPersonRepository personRepository)
        {
          this.PersonRepository = personRepository;
        }

        private IPersonRepository PersonRepository { get; }

        [HttpGet]
        public IActionResult GetAll()
        {
        
        System.Collections.Generic.IEnumerable<Person> people = PersonRepository.GetAll();

            if (people != null)
            {
                return new OkObjectResult(people);
            }
            return new OkObjectResult("");
            

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           
          var result = PersonRepository.Get(id);

          if (result != null)
          {
              return new OkObjectResult(result);
          }
            return new NotFoundResult();

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PersonUpdate personUpdate)
        {


            Person ourPerson = PersonRepository.Get(id);

            if (ourPerson != null)
            {
                ourPerson.Authorised = personUpdate.Authorised;
                ourPerson.Colours = personUpdate.Colours;
                ourPerson.Enabled = personUpdate.Enabled;

                return new OkObjectResult(PersonRepository.Update(ourPerson));

            }
            return new NotFoundResult();

        }
    }
}