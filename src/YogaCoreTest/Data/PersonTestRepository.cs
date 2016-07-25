using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaCore.Data;
using YogaCore.Models;

namespace YogaCoreTest.Data
{
    public class PersonTestRepository : IPersonRepository
    {
        private List<Person> _listPerson;

        public PersonTestRepository(List<Person> listPerson)
        {
            _listPerson = listPerson;
        }

        public async Task<Person> Create(Person item, string password)
        {
            _listPerson.Add(item);
            return await Task.Run(()=> { return item; });
        }

        public void Delete(Person item)
        {
            _listPerson.Remove(item);
        }

        public IEnumerable<Person> Get()
        {
            return _listPerson.ToList();
        }

        public Person Get(string id)
        {
            return _listPerson.Where(person => person.Id == id).FirstOrDefault();
        }

        public Person Update(Person item)
        {
            var selected = _listPerson.Where(person => person.Id == item.Id).FirstOrDefault();
            if (selected != null)
            {
                selected.BirthDate = item.BirthDate;
                selected.FirstName = item.FirstName;
                selected.Email = item.Email;
                selected.Sex = item.Sex;
                return selected;
            }
            else
            {
                return null;
            }
        }
    }
}
