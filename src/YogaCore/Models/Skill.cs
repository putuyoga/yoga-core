using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YogaCore.Models
{
    public class Skill
    {
        public Skill()
        {
            SkillId = Guid.NewGuid().ToString();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string SkillId { get; set; }

        [ForeignKey("Person")]
        public string PersonId { get; set; }

        public virtual Person Person { get; set; }

        /// <summary>
        /// The name of the skill
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The level skill
        /// </summary>
        [Range(1,10)]
        public int Level { get; set; }

    }
}
