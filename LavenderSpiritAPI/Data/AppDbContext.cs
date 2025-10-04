using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
        public DbSet<Models.EventUser> EventUsers { get; set; }
        public DbSet<Models.Organization> Organizations { get; set; }
        //public DbSet<Models.Organizator> Organizators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure entity relationships and constraints here if needed

            modelBuilder.Entity<Models.Voluntree>()
                .HasKey(v => v.VoluntreeID);

            modelBuilder.Entity<Models.LavEvent>()
                .HasKey(e => e.EventID);

            // Konfiguracja relacji właściciela eventu
            modelBuilder.Entity<Models.LavEvent>()
                .HasOne(e => e.Owner)
                .WithMany()
                .HasForeignKey(e => e.OwnerID)
                .OnDelete(DeleteBehavior.Restrict);

            // Konfiguracja relacji wiele-do-wielu przez EventUser
            modelBuilder.Entity<Models.EventUser>()
                .HasKey(eu => new { eu.VolunteerId, eu.EventId });

            modelBuilder.Entity<Models.EventUser>()
                .HasOne(eu => eu.Voluntree)
                .WithMany(v => v.EventUsers)
                .HasForeignKey(eu => eu.VolunteerId);

            modelBuilder.Entity<Models.EventUser>()
                .HasOne(eu => eu.Event)
                .WithMany(e => e.EventUsers)
                .HasForeignKey(eu => eu.EventId);

            modelBuilder.Entity<Models.Organization>()
                .HasKey(o => o.OrganizationID);

        }
    }
}
