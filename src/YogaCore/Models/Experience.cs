using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaCore.Models
{
    public class Experience
    {
        public Experience()
        {
            ExperienceId = Guid.NewGuid().ToString();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ExperienceId { get; set; }

        [ForeignKey("Person")]
        public string PersonId { get; set; }

        public virtual Person Person { get; set; }

        public string JobPosition { get; set; }

        public string CompanyName { get; set; }

        public DateTime Since { get; set; }

        public DateTime Until { get; set; }
    }
}
