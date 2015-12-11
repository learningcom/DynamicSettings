using System.Collections.Generic;

namespace DynamicSettings
{
    public abstract class ConstantSettings : ISettings
    {
        private readonly Dictionary<string, string> _map = new Dictionary<string, string>();

        public string Get(string key)
        {
            if(_map.Count == 0)
                InitializeValues();

            string val;
            return _map.TryGetValue(key, out val) ? val : null;
        }

        public IDictionary<string, string> GetAll()
        {
            if (_map.Count == 0)
                InitializeValues();

            return _map;
        }

        public void Set(string key, string value)
        {
            _map[key] = value;
        }

        protected abstract void InitializeValues();
    }
}
