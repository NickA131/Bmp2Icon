using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ServiceUtilities
{
    [RunInstaller(true)]
    public partial class WindowsServiceInstaller : Installer
    {
        private ServiceInstaller serviceInstaller;
        private ServiceProcessInstaller serviceProcessInstaller;

        public WindowsServiceInstaller()
        {
            serviceProcessInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();
            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            Installers.Add(serviceProcessInstaller);

            this.BeforeInstall += new InstallEventHandler(WindowsServiceInstaller_BeforeInstall);
            this.BeforeUninstall += new InstallEventHandler(WindowsServiceInstaller_BeforeUninstall);          
        }

        public void WindowsServiceInstaller_BeforeInstall(object sender, InstallEventArgs e)
        {
            Console.WriteLine("Running processes before install...");

            serviceInstaller.StartType = ServiceStartMode.Manual;

            serviceInstaller.ServiceName = this.Context.Parameters["ServiceName"].ToString();
            serviceInstaller.DisplayName = this.Context.Parameters["ServiceDisplayName"].ToString().Replace("\"", "");
            serviceInstaller.Description = this.Context.Parameters["ServiceDescription"].ToString().Replace("\"", "");

            Console.WriteLine("Service name is: " + serviceInstaller.DisplayName);

            Installers.Add(serviceInstaller);
        }

        public void WindowsServiceInstaller_BeforeUninstall(object sender, InstallEventArgs e)
        {
            Console.WriteLine("Running processes before uninstall...");

            serviceInstaller.ServiceName = this.Context.Parameters["ServiceName"].ToString();

            Console.WriteLine("Service name is: " + serviceInstaller.DisplayName);

            Installers.Add(serviceInstaller);
        }

    }
}
