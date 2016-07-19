using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YogaCore.Models
{
    public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public DateTime BirthDate { get; set; }

        [Range(0,1)]
        public Sex Sex { get; set; }
       
    }

    public enum Sex
    {
        Woman = 0,
        Man = 1
    }
}
