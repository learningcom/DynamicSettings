namespace DynamicSettings.Tests
{
    using NUnit.Framework;

    public class YamlSettingsTest
    {
        [Test]
        public void GetsSetting()
        {
            var settings = new YamlSettings("DynamicSettings.Tests\\TestFiles\\Config.yaml");

            var result = settings.Get("TestSetting1");

            Assert.AreEqual("TestSetting1Value", result);
        }

        [Test]
        public void GetsAllSettings()
        {
            var settings = new YamlSettings("DynamicSettings.Tests\\TestFiles\\Config.yaml");

            var result = settings.GetAll();

            Assert.AreEqual("TestSetting1Value", result["TestSetting1"]);
            Assert.AreEqual("TestSetting2Value", result["TestSetting2"]);
        }
    }
}
