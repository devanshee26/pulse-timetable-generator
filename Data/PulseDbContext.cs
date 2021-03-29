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

        public DbSet<User> User { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<TimeTable> TimeTable { get; set; }
    }
}
