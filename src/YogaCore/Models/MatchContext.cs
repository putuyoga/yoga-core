using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace YogaCore.Models
{
    public class MatchContext : DbContext
    {
        public MatchContext(DbContextOptions<MatchContext> options)
            : base(options)
        { }

        public DbSet<Person> Persons { get; set; }
    }
}
