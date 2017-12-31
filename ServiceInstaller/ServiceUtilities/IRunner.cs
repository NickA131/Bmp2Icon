using System;
using System.ServiceProcess;

namespace ServiceUtilities
{
    public interface IRunner
    {
        void Start(AccessibleServiceBase service, bool runAsService);
    }
}
