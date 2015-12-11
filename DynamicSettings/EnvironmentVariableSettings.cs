using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace DynamicSettings
{
    public class EnvironmentVariableSettings : ISettings
    {
        private readonly string _prefix;
        private readonly Dictionary<string,string> _variables;

        public EnvironmentVariableSettings(string prefix)
        {
            _prefix = prefix;

            var env = Environment.GetEnvironmentVariables();

            _variables = env.Keys
               .Cast<object>()
               .Where(x => x.ToString().StartsWith(prefix))
               .Select(x => new {k = x.ToString(), v = env[x].ToString()})
               .ToDictionary(x => x.k, x => x.v);
        }

        public string Get(string key)
        {
            var envVarName = (_prefix + key);

            string result;

            return _variables.TryGetValue(envVarName, out result) ? result : null;
        }

        public IDictionary<string, string> GetAll()
        {
            return _variables
                .Where(x => x.Key.StartsWith(_prefix))
                .ToDictionary(x => x.Key.Replace(_prefix, ""), x => x.Value);
        }
    }
}