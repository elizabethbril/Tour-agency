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

        public UnitOfWork()
        {
            ManagementContext = new ManagementContext();
            AgencyContext = new AgencyContext();
        }

        public UnitOfWork(ManagementContext ManagementContext, AgencyContext AgencyContext)
        {
            this.ManagementContext = ManagementContext;
            this.AgencyContext = AgencyContext;
        }


        private IRepository<Tour> _tourstemplates;
        private IRepository<Transport> _transports;

        private IRepository<TransportPlace> _transportsplases;
        private IRepository<User> _users;
        private IRepository<Tour> _orderedtours;

        public IRepository<Tour> ToursTemplates { get { if (_tourstemplates == null) _tourstemplates = new GenericRepository<Tour>(ManagementContext); return _tourstemplates; } }
        public IRepository<Transport> Transports { get { if (_transports == null) _transports = new GenericRepository<Transport>(ManagementContext); return _transports; } }

        public IRepository<User> Users { get { if (_users == null) _users = new GenericRepository<User>(AgencyContext); return _users; } }
        public IRepository<Tour> OrderedTours { get { if (_orderedtours == null) _orderedtours = new GenericRepository<Tour>(AgencyContext); return _orderedtours; } }
        public IRepository<TransportPlace> TransportsPlace { get { if (_transportsplases == null) _transportsplases = new GenericRepository<TransportPlace>(AgencyContext); return _transportsplases; } }

        public void DeleteDB()
        {
            ManagementContext.Database.Delete();
            AgencyContext.Database.Delete();

        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    ManagementContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
