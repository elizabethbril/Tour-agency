using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using DAL;
using DAL.Interfaces;
using DAL.UnitOfWork;

namespace LogicTests
{
    public class TestBinder : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}