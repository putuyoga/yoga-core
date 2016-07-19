using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using YogaCore.Models;

namespace YogaCore.Migrations
{
    [DbContext(typeof(MatchContext))]
    [Migration("20160718072932_FirstTime")]
    partial class FirstTime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YogaCore.Models.Person", b =>
                {
                    b.Property<string>("Id");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName");

                    b.Property<int>("Sex");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });
        }
    }
}
