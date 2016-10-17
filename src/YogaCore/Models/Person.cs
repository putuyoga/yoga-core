using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaCore.Models
{
    public class Person : IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override string Id { get; set; }

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

        public virtual ICollection<Skill> Skills { get; set; }

        public virtual ICollection<Experience> Experiences { get; set; }

        public virtual ICollection<Education> Educations { get; set; }
}

    public enum Sex
    {
        Woman = 0,
        Man = 1
    }
}
