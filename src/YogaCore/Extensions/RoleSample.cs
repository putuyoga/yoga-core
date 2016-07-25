using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YogaCore.Extensions
{
    public static class RoleSample
    {
        private static async Task EnsureRoleCreated(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
        public static async Task LoadSample(this RoleManager<IdentityRole> roleManager)
        {
            // add all roles, that should be in database, here
            await EnsureRoleCreated(roleManager, "Banned");
            await EnsureRoleCreated(roleManager, "Administrator");
        }
    }
}
