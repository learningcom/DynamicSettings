using System.IO;

namespace DynamicSettings
{
    public class FileSettings : ConstantSettings
    {
        private readonly string _path;
        private readonly string _pattern;

        public FileSettings(string path = ".", string pattern = "*.cfg")
        {
            _path = path;
            _pattern = pattern;
        }

        protected sealed override void InitializeValues()
        {
            foreach (var file in Directory.GetFiles(_path, _pattern))
            {
                Set(Path.GetFileNameWithoutExtension(file), File.ReadAllText(file));
            }
        }
    }
}