namespace DynamicSettings.Tests
{
    using NUnit.Framework;

    public class ConfigurationManagerSettingsTest
    {
        [Test]
        public void GetReturnsCorrectValue()
        {
            var settings = new ConfigurationManagerSettings();

            var result = settings.Get("TestSetting1");

            Assert.AreEqual("TestSetting1Value", result);
        }

        [Test]
        public void GetAllReturnsCorrectValue()
        {
            var settings = new ConfigurationManagerSettings();

            var result = settings.GetAll();

            Assert.AreEqual("TestSetting1Value", result["TestSetting1"]);
            Assert.AreEqual("TestSetting2Value", result["TestSetting2"]);
        }
    }
}
