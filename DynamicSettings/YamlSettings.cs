using System.IO;
using YamlDotNet.RepresentationModel;

namespace DynamicSettings
{
    public class YamlSettings : ConstantSettings
    {
        private readonly string _file;

        public YamlSettings(string file = "Config.yaml")
        {
            _file = file;
        }

        protected sealed override void InitializeValues()
        {
            if (!File.Exists(_file))
                return;

            using (var read = new StreamReader(_file))
            {
                var yamlStream = new YamlStream();
                yamlStream.Load(read);

                var mapping = (YamlMappingNode)yamlStream.Documents[0].RootNode;

                foreach (var n in mapping.Children)
                {
                    Set(((YamlScalarNode)n.Key).Value, ((YamlScalarNode)n.Value).Value);
                }
            }
        }
    }
}