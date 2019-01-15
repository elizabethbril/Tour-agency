using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Tour> Tours { get; }
        IRepository<Transport> Transports { get; }
        IRepository<User> Users { get; }
        IRepository<TransportPlace> TransportsPlace { get; }

        void SaveChanges();
        Task SaveChangesAsync();
        void SaveManagementChanges();
        Task SaveManagementChangesAsync();

        void RecreateDB();
        Task RecreateDBAsync();
        void RecreateManagement();

    }
}