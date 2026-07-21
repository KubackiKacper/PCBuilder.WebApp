using Microsoft.EntityFrameworkCore;
using PCBuilder.Domain.Entities;

namespace PCBuilder.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Service> Services => Set<Service>();
        public DbSet<ContactRequest> ContactRequests => Set<ContactRequest>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Service>()
                .Property(s => s.Name)
                .HasMaxLength(100);

            modelBuilder.Entity<ContactRequest>()
                .Property(c => c.Name)
                .HasMaxLength(100);
        }
    }
}
