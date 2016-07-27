using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YogaCoreTest.Data
{
    public class TrueIdentityResult : IdentityResult
    {
        public TrueIdentityResult()
        {
            Succeeded = true;
        }
    }
}
