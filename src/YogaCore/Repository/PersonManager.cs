using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaCore.Models;

namespace YogaCore.Data
{
    public class PersonManager : IIdentityManager
    {

        private readonly SignInManager<Person> _signInManager;
        private readonly UserManager<Person> _userManager;

        public PersonManager(
            SignInManager<Person> signInManager, 
            UserManager<Person> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterAsync(IdentityUser user, string password)
        {
            return await _userManager.CreateAsync(user as Person, password);
        }
    }
}
