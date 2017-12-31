using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using NinjaSoftwareLtd.ErrorLogging;

namespace ServiceUtilities
{
    public class UtilitySelector : IUtilitySelector
    {
        private IManagedInstaller _managedInstaller;
        private IRunner _runner;
        private IErrorLogger _errorLogger;
 
        public UtilitySelector(IManagedInstaller managedInstaller, IRunner runner, IErrorLogger errorLogger)
        {
            _managedInstaller = managedInstaller;
            _runner = runner;
            _errorLogger = errorLogger;
            _errorLogger.ClassName = typeof(UtilitySelector).ToString();
        }

        public void Select(string[] args, AccessibleServiceBase service, IConfiguration configuration, string assemblyFullName)
        {
            if (args == null) throw new ArgumentNullException("No arguments were specified.");
            if (service == null) throw new ArgumentNullException("Service is null.");
            if (configuration == null) throw new ArgumentNullException("Configuration is null.");
            if (assemblyFullName == null) throw new ArgumentNullException("AssemblyFullName is null.");

            var serviceName = configuration.ServiceName;
            var serviceDisplayName = configuration.ServiceDisplayName;
            var serviceDescription = configuration.ServiceDescription;

            if (string.IsNullOrEmpty(serviceName))  throw new NullReferenceException("ServiceName was not supplied.");
            if (string.IsNullOrEmpty(serviceDisplayName)) throw new NullReferenceException("ServiceDisplayName was not supplied.");
            if (string.IsNullOrEmpty(serviceDescription)) throw new NullReferenceException("ServiceDescription was not supplied.");
            
            if (args.Length > 0)
                switch (args[0])
                {
                    case "-i":
                        _errorLogger.LogInfo("Installing service: " + serviceDisplayName);
                        _managedInstaller.InstallHelper(serviceName, serviceDisplayName, serviceDescription, assemblyFullName);
                        break;
                    case "-u":
                        _errorLogger.LogInfo("Uninstalling service: " + serviceDisplayName);
                        _managedInstaller.InstallHelper(serviceName, serviceDisplayName, serviceDescription, assemblyFullName, true);
                        break;
                    case "-c":
                        _errorLogger.LogInfo("Running as a console application...");
                        _runner.Start(service, false);
                        break;
                }
            else
            {
                _errorLogger.LogInfo(serviceName + " service is starting...");
                _runner.Start(service, true);
            }
        }

    }
}
