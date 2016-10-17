using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaCore.Models;

namespace YogaCore.ViewModels.API
{
    public class PersonJsonData
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public DateTime BirthDate { get; set; }

        public Sex Sex { get; set; }
    }
}
