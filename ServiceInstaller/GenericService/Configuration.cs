using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceUtilities;

namespace GenericService
{
    public class Configuration : ServiceUtilities.IConfiguration
    {
        public string ServiceName {
            get { return ConfigurationManager.AppSettings["ServiceName"]; }
        }

        public string ServiceDisplayName {
            get{ return ConfigurationManager.AppSettings["ServiceDisplayName"]; }
        }

        public string ServiceDescription {
            get { return ConfigurationManager.AppSettings["ServiceDescription"]; }
        }
    }
}
