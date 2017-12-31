using System;
using System.Configuration.Install;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceUtilities
{
    public class ManagedInstaller : IManagedInstaller
    {
        public void InstallHelper(string serviceName, string serviceDisplayName, string serviceDescription, string assemblyFullName, bool uninstall = false)
        {

            var installerArgs = new List<string>() { "/ServiceName=" + serviceName, "/ServiceDisplayName=\"" + serviceDisplayName + "\"", "/ServiceDescription=\"" + serviceDescription + "\"", assemblyFullName };

            if (uninstall)
                installerArgs.Insert(0, "/u");

            ManagedInstallerClass.InstallHelper(installerArgs.ToArray());
        }
    }
}
