using DAL.Entities;
using System.Data.Entity;

namespace DAL
{
    public class ManagementContext : DbContext
    {
        public ManagementContext() : base("ManagementContext") { }
        public DbSet<Tour> TourTemplates { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<TransportPlace> TransportPlaces { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transport>()
           .HasMany(t => t.TransportPlaces)
           .WithRequired(t => t.Transport)
           .HasForeignKey(t => t.TransportId)
           .WillCascadeOnDelete();

            base.OnModelCreating(modelBuilder);
        }
    }
}