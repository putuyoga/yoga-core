using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;
using YogaCore.Data;
using YogaCore.Models;
using System.IO;
using Newtonsoft.Json;

namespace YogaCore.Extensions
{
    public static class DataSample
    {
        // Default credential 
        private const string PASSWORD = "1QAZwsx!";
        private const string ROLE = "Administrator";

        private static IHostingEnvironment _env;
        private static IApplicationBuilder _app;

        public static async Task CreateSample(
            this IApplicationBuilder app,
            IHostingEnvironment env)
        {
            _app = app;
            _env = env;

            // The order is matters. Be careful.
            await CreateRole();
            await CreateUser();
        }

        /// <summary>
        /// Create sample role which will be used later
        /// </summary>
        /// <returns></returns>
        private static async Task CreateRole()
        {
            var roleManager = _app.ApplicationServices.
                GetService(typeof(RoleManager<IdentityRole>)) as RoleManager<IdentityRole>;

            string[] roleList = new string[] { "Administrator", "Banned", "Member" };
            foreach (var roleName in roleList)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        /// <summary>
        /// Create a sample user, which is an administrator
        /// </summary>
        /// <returns></returns>
        private static async Task CreateUser()
        {
            var userManager = _app.ApplicationServices
                .GetService(typeof(UserManager<Person>)) as UserManager<Person>;

            // path to the json file
            var pathToFile = _env.ContentRootPath
               + Path.DirectorySeparatorChar.ToString()
               + "Assets"
               + Path.DirectorySeparatorChar.ToString()
               + "sample-person.json";

            string fileContent;

            using (StreamReader reader = File.OpenText(pathToFile))
            {
                fileContent = reader.ReadToEnd();
            }
            Person sampleUser = await Task.Factory.StartNew(() =>
                JsonConvert.DeserializeObject<Person>(fileContent));
                
            // If did not exist, create new person
            var existPerson = await userManager.FindByEmailAsync(sampleUser.Email);
            if (existPerson == null)
            {
                // create new user
                var result = await userManager.CreateAsync(sampleUser, PASSWORD);

                // assign role
                await userManager.AddToRoleAsync(sampleUser, ROLE);
            }
            else // otherwise check role, applied to administrator
            {
                var listRole = await userManager.GetRolesAsync(existPerson);
                if (!listRole.Contains(ROLE))
                {
                    await userManager.AddToRoleAsync(existPerson, ROLE);
                }
            }
            
        }
    }
}
