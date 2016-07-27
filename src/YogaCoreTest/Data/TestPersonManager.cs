using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using YogaCore.Data;

namespace YogaCoreTest.Data
{
    public class TestPersonManager : IIdentityManager
    {
        private Dictionary<string, string> _dictIdentity;

        public TestPersonManager(Dictionary<string, string> dictIdentity)
        {
            _dictIdentity = dictIdentity;
        }

        public Task<bool> LoginAsync(string username, string password)
        {
            var result = _dictIdentity
                .FirstOrDefault(id => id.Key == username && id.Value == password);
            return Task.Run(() => { return result.Key != null; });
        }

        public Task LogoutAsync()
        {
            // do nothing
            return new Task(null);
        }

        public async Task<IdentityResult> RegisterAsync(IdentityUser user, string password)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(password))
            {
                var error = new IdentityError()
                {
                    Code = "101",
                    Description = "Username/Password cant empty"
                };
                var result = IdentityResult.Failed(new IdentityError[] { error });
                return await Task.Run(() => { return result; });
            }

            else if(_dictIdentity.ContainsKey(user.UserName))
            {
                var error = new IdentityError()
                {
                    Code = "102",
                    Description = "Username already exist"
                };
                var result = IdentityResult.Failed(new IdentityError[] { error });
                return await Task.Run(() => { return result; });
            }
            else
            {
                _dictIdentity.Add(user.UserName, password);
                return await Task.Run(() => { return new TrueIdentityResult(); });
            }
        }
    }
}
