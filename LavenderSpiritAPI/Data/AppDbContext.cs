using Microsoft.EntityFrameworkCore;

namespace LavenderSpiritAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // Define DbSets for your entities
        public DbSet<Models.Voluntree> Voluntrees { get; set; }
        public DbSet<Models.LavEvent> Events { get; set; }
        //public DbSet<Models.Organizator> Organizators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure entity relationships and constraints here if needed

            modelBuilder.Entity<Models.Voluntree>()
                .HasKey(v => v.VoluntreeID);

            modelBuilder.Entity<Models.LavEvent>()
                .HasKey(e => e.EventID);

            modelBuilder.Entity<Models.LavEvent>()
                .HasOne(e => e.Owner)
                .WithMany(v => v.OwnedEvents)
                .HasForeignKey(e => e.OwnerID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
