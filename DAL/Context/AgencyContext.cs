using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using System.Data.Entity;

namespace DAL.Context
{
    internal class AgencyContext : DbContext
    {
        public AgencyContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new AgencyContextInitializer());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<TransportTicket> TransportTickets { get; set; }
        public DbSet<Tour> OrderedTours { get; set; }
    }

    internal class AgencyContextInitializer : CreateDatabaseIfNotExists<AgencyContext>
    {
        protected override void Seed(AgencyContext context)
        {
            base.Seed(context);
        }
    }

}