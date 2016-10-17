using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaCore.Models
{
    public class Education
    {
        public Education()
        {
            EducationId = Guid.NewGuid().ToString();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string EducationId { get; set; }

        [ForeignKey("Person")]
        public string PersonId { get; set; }

        public virtual Person Person { get; set; }

        public string SchoolName { get; set; }

        public string Major { get; set; }

        public DateTime Since { get; set; }

        public DateTime Until { get; set; }
    }
}
