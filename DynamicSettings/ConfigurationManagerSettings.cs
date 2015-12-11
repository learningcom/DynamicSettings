using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace DynamicSettings
{
    public class ConfigurationManagerSettings : ISettings
    {
        public string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public IDictionary<string, string> GetAll()
        {
            return ConfigurationManager.AppSettings.AllKeys.ToDictionary(x => x, x => ConfigurationManager.AppSettings[x].ToString());
        }
    }
}