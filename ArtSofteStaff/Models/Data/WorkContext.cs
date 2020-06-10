using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtSofteStaff.Models.Data
{
    public class WorkContext : DbContext
    {
        public WorkContext(DbContextOptions<WorkContext> options) : base(options)
        {
            // Database.EnsureCreated();
        }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
