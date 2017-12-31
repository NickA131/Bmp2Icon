using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.ServiceProcess;
using System.Threading;
using ServiceUtilities;

namespace GenericService
{
    public class GenericService : AccessibleServiceBase
    {
        private ManualResetEvent _shutdownEvent = new ManualResetEvent(false);
        private Thread _thread;

        public GenericService(IConfiguration configuration)
        {
            this.ServiceName = configuration.ServiceName;
        }

        protected override void OnStart(string[] args)
        {
            // Start-up service
            EventLog.WriteEntry(string.Format("Starting Service '{0}'...", Assembly.GetExecutingAssembly().FullName), EventLogEntryType.Information);

            _thread = new Thread(WorkerThreadFunc);
            _thread.IsBackground = true;
            _thread.Start();

        }

        protected override void OnStop()
        {
            // Stop service
            EventLog.WriteEntry(string.Format("Stopping Service '{0}'.", Assembly.GetExecutingAssembly().FullName), EventLogEntryType.Information);

            _shutdownEvent.Set();
            if (!_thread.Join(3000))
            {
                _thread.Abort();
            }

        }

        private void WorkerThreadFunc()
        {
            while (!_shutdownEvent.WaitOne(0))
            {
                // Service code


            }
        }

    }
}
