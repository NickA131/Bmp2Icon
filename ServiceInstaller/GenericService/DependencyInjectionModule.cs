using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using ServiceUtilities;
using NinjaSoftwareLtd.ErrorLogging;

namespace GenericService
{
    public class DependencyInjectionModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IManagedInstaller>().To<ManagedInstaller>();
            Bind<IRunner>().To<Runner>();
            Bind<IErrorLogger>().To<NLogErrorLogger>();
            
            Bind<IConfiguration>().To<Configuration>();
            
            Bind<IUtilitySelector>().To<UtilitySelector>();

            Bind<AccessibleServiceBase>().To<GenericService>();
        }
    }
}
