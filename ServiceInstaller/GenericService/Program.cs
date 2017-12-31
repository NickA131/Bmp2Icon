using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using NinjaSoftwareLtd.ErrorLogging;
using ServiceUtilities;

namespace GenericService
{
    class Program
    {
        static void Main(string[] args)
        {
            var applicationLogger = new NLogErrorLogger();
            applicationLogger.ClassName = typeof(Program).ToString();

            try
            {
                var kernel = new StandardKernel(new DependencyInjectionModule());
                var utilitySelector = kernel.Get<IUtilitySelector>();
                var configuration = kernel.Get<IConfiguration>();
                var service = kernel.Get<AccessibleServiceBase>();

                utilitySelector.Select(args, service, configuration, Assembly.GetExecutingAssembly().Location);

            }
            catch (Exception ex)
            {
                applicationLogger.LogError("Fatal error has occurred: " + ex.Message, ex);
            }
        }
    }
}
