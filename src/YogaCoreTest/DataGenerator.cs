using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaCore.Models;

namespace YogaCoreTest
{
    public class DataGenerator : IEnumerable<Person>
    {
        public DataGenerator()
        {
            _data = new List<Person>()
            {
                new Person
                {
                    FirstName = "Rocky",
                    BirthDate = new DateTime(1925, 12, 11),
                    Sex = Sex.Man
                },
                new Person
                {
                    FirstName = "Madonna",
                    BirthDate = new DateTime(1945, 5, 22),
                    Sex = Sex.Woman
                },
                new Person
                {
                    FirstName = "Goldan",
                    BirthDate = new DateTime(1968, 2, 12),
                    Sex = Sex.Man
                },
                new Person
                {
                    FirstName = "Lyanna",
                    BirthDate = new DateTime(1988, 7, 29),
                    Sex = Sex.Woman
                },
                new Person
                {
                    FirstName = "Marco",
                    BirthDate = new DateTime(1999, 4, 3),
                    Sex = Sex.Man
                }
            };
        }

        private List<Person> _data;

        public IEnumerator<Person> GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
            
        }
    }
}
