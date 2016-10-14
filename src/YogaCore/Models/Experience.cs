using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaCore.Models
{
    public class Experience
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExperienceId { get; set; }

        public virtual Person Person { get; set; }

        public string JobPosition { get; set; }

        public string CompanyName { get; set; }

        public DateTime Since { get; set; }

        public DateTime Until { get; set; }
    }
}
