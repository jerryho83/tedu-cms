using System.Configuration;

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