using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ManagementContext ManagementContext;
        private AgencyContext AgencyContext;

        public UnitOfWork(string managementContextConnectionString, string agencyContextConnectionString)
        {
            ManagementContext = new ManagementContext(managementContextConnectionString);
            AgencyContext = new AgencyContext(agencyContextConnectionString);
        }


        private IRepository<Tour> _tours;
        private IRepository<Transport> _transports;

        private IRepository<TransportPlace> _transportsplases;
        private IRepository<User> _users;

        public IRepository<Tour> Tours { get { if (_tours == null) _tours = new GenericRepository<Tour>(ManagementContext); return _tours; } }
        public IRepository<Transport> Transports { get { if (_transports == null) _transports = new GenericRepository<Transport>(ManagementContext); return _transports; } }
        public IRepository<User> Users { get { if (_users == null) _users = new GenericRepository<User>(AgencyContext); return _users; } }
        public IRepository<TransportPlace> TransportsPlace { get { if (_transportsplases == null) _transportsplases = new GenericRepository<TransportPlace>(AgencyContext); return _transportsplases; } }

        public void DeleteDB()
        {
            ManagementContext.Database.Delete();
            AgencyContext.Database.Delete();

        }

        public void RecreateDB()
        {
            AgencyContext.Database.Delete();
            AgencyContext.Database.Create();
        }

        public async Task RecreateDBAsync()
        {
            await new Task(() => AgencyContext.Database.Delete());
            await new Task(() => AgencyContext.Database.Create());
        }

        public void RecreateManagement()
        {
            ManagementContext.Database.Delete();
            ManagementContext.Database.Create();
        }

        public void SaveChanges()
        {
            lock (AgencyContext)
            {
                AgencyContext.SaveChanges();
            }
        }

        public async Task SaveChangesAsync()
        {
            await AgencyContext.SaveChangesAsync();
        }

        public void SaveManagementChanges()
        {
            lock (ManagementContext)
            {
                ManagementContext.SaveChanges();
            }
        }

        public async Task SaveManagementChangesAsync()
        {
            await ManagementContext.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    AgencyContext.Dispose();
                    ManagementContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
