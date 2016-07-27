using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YogaCore.Data
{
    public interface IIdentityManager
    {
        Task<bool> LoginAsync(string username, string password);

        Task<IdentityResult> RegisterAsync(IdentityUser user, string password);

        Task LogoutAsync();
    }
}
