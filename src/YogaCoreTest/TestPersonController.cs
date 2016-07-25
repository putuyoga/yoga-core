using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using YogaCore.Controllers.API;
using YogaCore.Models;
using YogaCoreTest.Data;

namespace YogaCoreTest
{
    
    public class TestPersonController
    {
        public TestPersonController()
        {
        }

        [Fact]
        public void GetAllPerson_ShouldReturnAllPerson()
        {
            // create sample data
            var listPerson = new List<Person>()
            {
                new Person() {FirstName = "A" },
                new Person() {FirstName = "B" },
                new Person() {FirstName = "B" },
                new Person() {FirstName = "C" },
            };

            var repository = new PersonTestRepository(listPerson);
            var controller = new PersonController(repository);

            Assert.Equal(4, controller.Get().Count());
        }


    }
}
