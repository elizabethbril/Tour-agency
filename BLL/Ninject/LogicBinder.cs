using DAL.Interfaces;
using DAL.UnitOfWork;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Ninject
{
    public class LogicBinder : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}
