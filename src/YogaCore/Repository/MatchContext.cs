using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace YogaCore.Models
{
    public class MatchContext : IdentityDbContext
    {
        public MatchContext(DbContextOptions<MatchContext> options)
            : base(options)
        { }

        public DbSet<Person> Persons { get; set; }
        
        public DbSet<Skill> Skills { get; set; }

        public DbSet<Experience> Experiences { get; set; }

        public DbSet<Education> Educations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
