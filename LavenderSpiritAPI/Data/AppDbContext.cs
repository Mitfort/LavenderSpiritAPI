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

        }
    }
}
