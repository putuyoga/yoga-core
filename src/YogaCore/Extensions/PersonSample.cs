using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using YogaCore.Models;

namespace YogaCore.Extensions
{
    public static class PersonSample
    {
        /// <summary>
        /// Create some sample person data
        /// </summary>
        /// <param name="userManager">Instance that do some basic operation for user</param>
        /// <returns></returns>
        public static async Task LoadSample(this UserManager<Person> userManager)
        {
            // Look up the person first
            var email = "putuyoga@outlook.com";
            var role = "Administrator";
            var existPerson = await userManager.FindByEmailAsync(email);

            // this person did not exist, so just create them anyway
            if (existPerson == null)
            {
                var person = new Person()
                {
                    FirstName = "I Putu Yoga Permana",
                    BirthDate = DateTime.Now,
                    Sex = Sex.Man,
                    Email = email
                };

                // create person
                var result = await userManager.CreateAsync(person, "putuyoga@GMAIL.com");
                var newPerson = await userManager.FindByEmailAsync(email);

                // assign role
                await userManager.AddToRoleAsync(newPerson, role);
            }
            else // otherwise check role, applied to administrator
            {
                var listRole = await userManager.GetRolesAsync(existPerson);
                if(!listRole.Contains(role))
                {
                    await userManager.AddToRoleAsync(existPerson, role);
                }
            }
        }
    }
}
