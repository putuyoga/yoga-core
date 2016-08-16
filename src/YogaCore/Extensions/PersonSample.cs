using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using YogaCore.Models;

namespace YogaCore.Extensions
{
    public static class PersonSample
    {
        private static UserManager<Person> _userManager;

        /// <summary>
        /// Create some sample person data
        /// </summary>
        /// <param name="userManager">Instance that do some basic operation for user</param>
        /// <returns></returns>
        public static async Task LoadSample(this UserManager<Person> userManager)
        {

            var person = new Person()
            {
                FirstName = "I Putu Yoga Permana",
                BirthDate = DateTime.Now,
                Sex = Sex.Man,
                UserName = "putuyoga@outlook.com",
                Email = "putuyoga@outlook.com"
            };

            var createUser = new Func<Person, string, string, Task>(CreateUser);
            await createUser.Invoke(person, "weas12!", "Administrator");
        }

        private async static Task CreateUser(
            Person person, 
            string password, 
            string role)
        {
            // If did not exist, create new person
            var existPerson = await _userManager.FindByEmailAsync(person.Email);
            if (existPerson == null)
            {

                var result = await _userManager.CreateAsync(person, password);
                var newCreatedPerson = await _userManager.FindByEmailAsync(person.Email);

                // assign role
                await _userManager.AddToRoleAsync(newCreatedPerson, role);
            }
            else // otherwise check role, applied to administrator
            {
                var listRole = await _userManager.GetRolesAsync(existPerson);
                if (!listRole.Contains(role))
                {
                    await _userManager.AddToRoleAsync(existPerson, role);
                }
            }
        }
    }
}
