using BLL.Interfaces;
using BLL.Logics;
using DAL.Interfaces;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Ninject
{
    public static class LogicDependencyResolver
    {
        static UnitOfWork UoW;

        public  static IUnitOfWork ResolveUnitOfWork()
        {
            return new UnitOfWork("AgencyContext", "ManagementContext");
        }


        public static IUserLogic ResolveUserAccountOperationsHandler()
        {
            return new UserLogic (ResolveUnitOfWork(), ResolveTourOperationsHandler());
        }

        public static ITourLogic ResolveTourOperationsHandler()
        {
            return new TourLogic(ResolveUnitOfWork(), ResolveUserAccountOperationsHandler());
        }

    }
}
