using System.Collections.Generic;

namespace DynamicSettings
{
    public interface ISettings
    {
        string Get(string key);
        IDictionary<string, string> GetAll();
    }
}