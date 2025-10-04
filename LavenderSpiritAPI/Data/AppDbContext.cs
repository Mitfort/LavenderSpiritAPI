using Microsoft.EntityFrameworkCore;

namespace LavenderSpiritAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // Define DbSets for your entities
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Event> Events { get; set; }
        public DbSet<Models.Organizator> Organizators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure entity relationships and constraints here if needed

            modelBuilder.Entity<Models.User>().HasIndex(p => p.UserID).IsUnique();
            modelBuilder.Entity<Models.Event>().HasIndex(p => p.EventID).IsUnique();
            modelBuilder.Entity<Models.Organizator>().HasIndex(p => p.UserID).IsUnique();
        }
    }
}
