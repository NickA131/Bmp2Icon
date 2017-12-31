using System;
namespace ServiceUtilities
{
    public interface IManagedInstaller
    {
        void InstallHelper(string serviceName, string serviceDisplayName, string serviceDescription, string assemblyFullName, bool uninstall = false);
    }
}
