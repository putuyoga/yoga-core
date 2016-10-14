using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaCore.Models
{
    public class Person : IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PersonId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Job Title of the Person
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// URL avatar photo of the person
        /// </summary>
        public string ImageUrl { get; set; }

        public string Website { get; set; }

        public string Location { get; set; }

        [Range(0, 1)]
        public Sex Sex { get; set; }

        public ICollection<Skill> Skills { get; set; }

        public ICollection<Experience> Experiences { get; set; }

        public ICollection<Education> Educations { get; set; }
}

    public enum Sex
    {
        Woman = 0,
        Man = 1
    }
}
