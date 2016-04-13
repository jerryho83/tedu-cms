using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEDU.Common.Helper
{
    public class ConfigHelper
    {
        public static string GetConfigByKey(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
}
