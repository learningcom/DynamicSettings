using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace DynamicSettings
{
    public class AppSettings : DynamicObject
    {
        private readonly List<ISettings> _providers;

        public AppSettings(params ISettings[] providers)
        {
            _providers = providers.Length == 0 ? new List<ISettings> {new ConfigurationManagerSettings()} : new List<ISettings>(providers);
        }

        public void AddProvider(ISettings settings, int? at)
        {
            if (at == null)
            {
                _providers.Add(settings);
            }
            else
            {
                _providers.Insert(at.Value, settings);
            }
        }

        public IDictionary<string, string> All
        {
            get
            {
                var result = new Dictionary<string, string>();

                foreach (var provider in _providers)
                {
                    var all = provider.GetAll();

                    foreach (var key in all.Keys.Where(x => !x.Contains("Private")))
                        result[key] = all[key];
                }

                return result;

            }
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            foreach (var provider in _providers)
            {
                var val = provider.Get(binder.Name);
                if (val != null)
                {
                    result = val;
                    return true;
                }
            }
            result = null;
            return true;
        }
    }
}