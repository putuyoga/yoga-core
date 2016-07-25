using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using YogaCore.Models;
using Microsoft.EntityFrameworkCore;
using YogaCore.ViewModels.API;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using YogaCore.Data;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace YogaCore.Controllers.API
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private IPersonRepository _repository;

        public PersonController(IPersonRepository repository)
        {
            _repository = repository;
        }

        // GET: api/person
        [HttpGet]
        public IEnumerable<PersonJsonData> Get()
        {
            return _repository.Get()
                .Select(person => new PersonJsonData()
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    BirthDate = person.BirthDate,
                    Sex = person.Sex
                }).ToList();
        }

        // GET api/person/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var personEntity = _repository.Get(id);

            // Check if that entity is exist
            if (personEntity == null)
            {
                return NotFound();
            }

            // Bundle & expose only relevant properties
            var jsonData = new PersonJsonData()
            {
                Id = personEntity.Id,
                FirstName = personEntity.FirstName,
                Sex = personEntity.Sex,
                BirthDate = personEntity.BirthDate
            };
            return new ObjectResult(jsonData);
        }

        // POST api/values
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PersonJsonData value)
        {
            if(ModelState.IsValid)
            {
                var randomEmail = Guid.NewGuid().ToString() + "@changethis.com";
                var user = new Person
                {
                    UserName = randomEmail,
                    Email = randomEmail,
                    BirthDate = value.BirthDate,
                    Sex = value.Sex,
                    FirstName = value.FirstName
                };

                await _repository.Create(user, "!weAs12");
                return CreatedAtAction("Get", user.Id);
            }
            return BadRequest();
        }

        // PUT api/person/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]PersonJsonData value)
        {
            if (ModelState.IsValid)
            {
                Person entity = _repository.Get(id);
                if (entity == null)
                {
                    return NotFound();
                }
                
                // Update the selected value
                entity.FirstName = value.FirstName;
                entity.BirthDate = value.BirthDate;
                entity.Sex = value.Sex;

                _repository.Update(entity);

                return NoContent();
            }
            else
            {
                return BadRequest();
            }
            
        }
        // DELETE api/person/5
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var personEntity = _repository.Get(id);
            if(personEntity == null)
            {
                return BadRequest();
            }

            _repository.Delete(personEntity);

            return NoContent();
        }
    }
}
