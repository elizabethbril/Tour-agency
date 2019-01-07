using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interfaces;
using BLL.Logics;
using Ninject.Modules;

namespace TourAgency.Ninject
{

    public class Binder : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserLogic>().To<UserLogic>();
            Bind<ITransportLogic>().To<TransportLogic>();
            Bind<ITourLogic>().To<TourLogic>();
        }
    }

}