using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using YogaCore.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace YogaCore.Controllers.API
{
    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        private MatchContext _context;

        public PersonController(MatchContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _context.Persons.ToList();
        }

        // GET: api/values/man
        [HttpGet("man")]
        public IEnumerable<Person> GetBySexMan()
        {
            return _context.Persons
                .Where(person => person.Sex == Sex.Man).ToList();
        }

        // GET: api/values/man
        [HttpGet("woman")]
        public IEnumerable<Person> GetBySexWoman()
        {
            return _context.Persons
                .Where(person => person.Sex == Sex.Woman).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var personEntity = _context.Persons.FirstOrDefault(person => person.Id == id);
            if(personEntity == null)
            {
                return NotFound();
            }
            return new ObjectResult(personEntity);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Person value)
        {
            if(ModelState.IsValid)
            {
                // Assign the new guid the newly created item
                value.Id = Guid.NewGuid().ToString();

                _context.Persons.Add(value);
                _context.SaveChanges();
                return CreatedAtAction("Get", value.Id);
            }
            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]Person value)
        {
            // Make sure assigned
            value.Id = id;

            _context.Persons.Attach(value);
            var entry = _context.Entry(value);
            entry.State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return NotFound();
            }

            return NoContent();
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var personEntity = _context.Persons.FirstOrDefault(person => person.Id == id);
            if(personEntity == null)
            {
                return BadRequest();
            }
            _context.Remove(personEntity);

            return NoContent();
        }
    }
}
