using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pulse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.Data
{
    public class PulseDbContext : IdentityDbContext
    {
        public PulseDbContext(DbContextOptions<PulseDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }

        public DbSet<User> User { get; set; }
        public DbSet<TimeTable> TimeTable { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
       

    }
}
