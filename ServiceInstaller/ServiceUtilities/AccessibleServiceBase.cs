using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServiceUtilities
{
    public class AccessibleServiceBase : ServiceBase
    {
        public void StartService(string[] args)
        {
            OnStart(args);
        }

        public void StopService()
        {
            OnStop();
        }

    }
}
