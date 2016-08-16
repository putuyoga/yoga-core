using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using YogaCore.Extensions;
using System.Threading.Tasks;
using YogaCore.Models;

namespace YogaCore.Extensions
{
    public static class DataSample
    {
        public static async Task LoadSample(this IApplicationBuilder app)
        {
            var userManager = app.ApplicationServices
                .GetService(typeof(UserManager<Person>)) as UserManager<Person>;
            var roleManager = app.ApplicationServices.
                GetService(typeof(RoleManager<IdentityRole>)) as RoleManager<IdentityRole>;

            // The order is matters
            // Role first, then user
            await roleManager.LoadSample();
            await userManager.LoadSample();
            
        }
    }
}
