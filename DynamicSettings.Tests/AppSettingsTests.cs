namespace DynamicSettings.Tests
{
    using System.Collections.Generic;
    using FakeItEasy;
    using NUnit.Framework;

    public class AppSettingsTests
    {
        [Test]
        public void AllReturnsAllSettings()
        {
            var fakeSettings1 = A.Fake<ISettings>();
            var fakeSettings2 = A.Fake<ISettings>();
            A.CallTo(() => fakeSettings1.GetAll()).Returns(new Dictionary<string, string> { { "TestSetting1", "TestSetting1Value" }});
            A.CallTo(() => fakeSettings2.GetAll()).Returns(new Dictionary<string, string> { { "TestSetting2", "TestSetting2Value" } });
            var appSettings = new AppSettings(fakeSettings1, fakeSettings2);

            var result = appSettings.All;

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("TestSetting1Value", result["TestSetting1"]);
            Assert.AreEqual("TestSetting2Value", result["TestSetting2"]);
        }

        [Test]
        public void AllDoesNotReturnPrivateSettings()
        {
            var fakeSettings1 = A.Fake<ISettings>();
            var fakeSettings2 = A.Fake<ISettings>();
            A.CallTo(() => fakeSettings1.GetAll()).Returns(new Dictionary<string, string> { { "TestSetting1", "TestSetting1Value" } });
            A.CallTo(() => fakeSettings2.GetAll()).Returns(new Dictionary<string, string> { { "PrivateTestSetting2", "TestSetting2Value" } });
            var appSettings = new AppSettings(fakeSettings1, fakeSettings2);

            var result = appSettings.All;

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("TestSetting1Value", result["TestSetting1"]);
            Assert.IsFalse(result.ContainsKey("PrivateTestSetting2"));
        }

        [Test]
        public void ReturnsCorrectSingleSetting()
        {
            var fakeSettings1 = A.Fake<ISettings>();
            var fakeSettings2 = A.Fake<ISettings>();
            A.CallTo(() => fakeSettings1.Get("TestSetting1")).Returns("TestSetting1Value");
            dynamic appSettings = new AppSettings(fakeSettings1, fakeSettings2);

            var result = appSettings.TestSetting1;

            Assert.AreEqual("TestSetting1Value", result);
        }
    }
}
