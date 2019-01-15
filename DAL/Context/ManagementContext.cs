using DAL.Entities;
using System.Data.Entity;

namespace DAL
{
    public class ManagementContext : DbContext
    {
        public ManagementContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new ManagementContextInitializer());
        }
        public DbSet<Tour> TourTemplates { get; set; }
        public DbSet<Transport> Transports { get; set; }
        public DbSet<TransportPlace> TransportPlaces { get; set; }
        public DbSet<User> Users { get; set; }

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
    
    internal class ManagementContextInitializer : CreateDatabaseIfNotExists<ManagementContext>
    {
        protected override void Seed(ManagementContext context)
        {
            context.Users.Add(new User{ Email = "admin", Name = "Liza", Surname = "Bril", TelephoneNumber = "+380992243828" });
            base.Seed(context);
        }
    }
}