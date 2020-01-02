namespace DynamicSettings.Tests
{
    using NUnit.Framework;

    public class FileSettingsTest
    {
        private FileSettings _fileSettings;

        [SetUp]
        public void SetupTests()
        {
            _fileSettings = new FileSettings("DynamicSettings.Tests\\TestFiles\\", "*.key");
        }

        [Test]
        public void GetsValuesFromFile()
        {
            var result = _fileSettings.Get("TestSetting1");

            Assert.AreEqual("TestSetting1Value", result);
        }

        [Test]
        public void GetsAllValuesFromFiles()
        {
            var result = _fileSettings.GetAll();

            Assert.AreEqual("TestSetting1Value", result["TestSetting1"]);
            Assert.AreEqual("TestSetting2Value", result["TestSetting2"]);
        }
    }
}
