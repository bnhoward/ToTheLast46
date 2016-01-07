using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nightjar.ToTheLast.Utility
{
    public class ConfigWrapper
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.AppSettings["connString"]; }
        }
    }
}
