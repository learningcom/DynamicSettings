namespace DynamicSettings.Tests
{
    using NUnit.Framework;

    public class ConstantSettingsTest
    {
        [Test]
        public void GetsAndSetsValues()
        {
            var constantSettings = new TestSettings();
            
            var setting1 = constantSettings.Get("Setting1");
            var setting2 = constantSettings.Get("Setting2");

            Assert.AreEqual("Setting1Value", setting1);
            Assert.AreEqual("Setting2Value", setting2);
        }

        [Test]
        public void GetsAllValues()
        {
            var constantSettings = new TestSettings();

            var result = constantSettings.GetAll();

            Assert.AreEqual("Setting1Value", result["Setting1"]);
            Assert.AreEqual("Setting2Value", result["Setting2"]);
        }

        internal class TestSettings : ConstantSettings
        {
            protected override void InitializeValues()
            {
                Set("Setting1", "Setting1Value");
                Set("Setting2", "Setting2Value");
            }
        }
    }
}
