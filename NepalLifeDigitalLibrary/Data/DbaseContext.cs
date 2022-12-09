using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DigitalLibrarySystem.Models;

namespace DigitalLibrarySystem.Data
{
    public class DbaseContext : IdentityDbContext
    {
        public DbaseContext(DbContextOptions<DbaseContext> options)
            : base(options)
        {
        }

        public DbSet<Department>? Departments {get; set;}
        public DbSet<DocumentModel>? Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationConfigurations>()
                .HasNoKey();
        }
    }
}
