using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaCore.Models;

namespace YogaCore.Data
{
    public class PersonRepository : IPersonRepository
    {
        private MatchContext _context;
        private UserManager<Person> _userManager;

        public PersonRepository(MatchContext context, UserManager<Person> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public Person Get(string id)
        {
            var person = _context.Persons
                .Single(p => p.Id == id);

            _context.Skills
                .Where(s => s.PersonId == id).Load();

            _context.Educations
                .Where(e => e.PersonId == id).Load();

            _context.Experiences
                .Where(e => e.PersonId == id).Load();

            return person;
        }

        public IEnumerable<Person> Get()
        {
            return _context.Persons.ToList();
        }

        public async Task<Person> Create(Person item, string password)
        {
            await _userManager.CreateAsync(item, password);
            return item;
        }

        public Person Update(Person item)
        {
            _context.Persons.Attach(item);
            var entry = _context.Entry(item);
            entry.State = EntityState.Modified;
            _context.SaveChanges();

            return item;
        }

        public void Delete(Person item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }
    }
}
