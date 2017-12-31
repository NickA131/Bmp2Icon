using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServiceUtilities
{
    public class Runner : IRunner
    {
        public void Start(AccessibleServiceBase service, bool runAsService)
        {
            var sctr = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == service.ServiceName);
            if (sctr == null)
            {
                Console.WriteLine("Service '{0}' is not installed", service.GetType().Name);
                return;
            }

            if (runAsService)
            {
                var ServiceToRun = new ServiceBase[] { service };
                ServiceBase.Run(ServiceToRun);
            }
            else
            {
                service.StartService(null);
                Console.WriteLine("Press any key to exit...");
                Console.ReadLine();
                service.StopService();
            }
            
        }
    }
}
