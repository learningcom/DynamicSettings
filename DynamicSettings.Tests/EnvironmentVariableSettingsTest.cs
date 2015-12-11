namespace DynamicSettings.Tests
{
    using System;
    using NUnit.Framework;

    public class EnvironmentVariableSettingsTest
    {
        [Test]
        public void GetsCorrectEnvironmentVariable()
        {
            Environment.SetEnvironmentVariable("Test_Setting1", "TestSetting1Value");
            var environmentVariableSettings = new EnvironmentVariableSettings("Test_");

            var result = environmentVariableSettings.Get("Setting1");

            Assert.AreEqual("TestSetting1Value", result);
        }

        [Test]
        public void GetsAllEnvironmentVariableSettings()
        {
            Environment.SetEnvironmentVariable("Test_Setting1", "TestSetting1Value");
            Environment.SetEnvironmentVariable("Test_Setting2", "TestSetting2Value");
            var environmentVariableSettings = new EnvironmentVariableSettings("Test_");

            var result = environmentVariableSettings.GetAll();

            Assert.AreEqual("TestSetting1Value", result["Setting1"]);
            Assert.AreEqual("TestSetting2Value", result["Setting2"]);
        }
    }
}
