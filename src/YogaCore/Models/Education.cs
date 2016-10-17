using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaCore.Models
{
    public class Education
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid EducationId { get; set; }

        public Guid PersonId { get; set; }

        public virtual Person Person { get; set; }

        public string SchoolName { get; set; }

        public string Major { get; set; }

        public DateTime Since { get; set; }

        public DateTime Until { get; set; }
    }
}
