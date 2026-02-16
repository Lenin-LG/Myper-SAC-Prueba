using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace Trabajadores.Infrastructure.Persistence
{
    public class WorkerDbContext : DbContext
    {
        public DbSet<Worker> Workers => Set<Worker>();

        public WorkerDbContext(DbContextOptions<WorkerDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>(e =>
            {
                e.HasKey(x => x.Id);

                e.Property(x => x.FirstName).IsRequired().HasMaxLength(150);
                e.Property(x => x.LastName).IsRequired().HasMaxLength(150);
                e.Property(x => x.DocumentNumber).IsRequired().HasMaxLength(20);

                e.HasIndex(x => x.DocumentNumber).IsUnique();
                e.Property(x => x.Gender).HasConversion<string>();

                e.Property(x => x.DocumentType).HasConversion<string>();
            });
        }

    }
}
