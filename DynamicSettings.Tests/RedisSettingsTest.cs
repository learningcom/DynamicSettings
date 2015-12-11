namespace DynamicSettings.Tests
{
    using FakeItEasy;
    using NUnit.Framework;
    using StackExchange.Redis;

    public class RedisSettingsTest
    {
        [Test]
        public void GetsSetting()
        {
            var redis = A.Fake<IDatabase>();
            A.CallTo(redis).Where(r => r.Method.Name == "HashGet" && (RedisKey)r.Arguments[0] == "AppSettings" && (RedisValue)r.Arguments[1] == "TestSetting1")
                .WithReturnType<RedisValue>()
                .Returns("TestSetting1Value");
            var redisSettings = new RedisSettings(redis);

            var result = redisSettings.Get("TestSetting1");

            Assert.AreEqual("TestSetting1Value", result);
        }

        [Test]
        public void GetsAllSettings()
        {
            var redis = A.Fake<IDatabase>();
            var returnValue = new [] { new HashEntry("TestSetting1", "TestSetting1Value"), new HashEntry("TestSetting2", "TestSetting2Value") };
            A.CallTo(redis).Where(r => r.Method.Name == "HashGetAll" && (RedisKey)r.Arguments[0] == "AppSettings")
                .WithReturnType<HashEntry[]>()
                .Returns(returnValue);
            var redisSettings = new RedisSettings(redis);

            var result = redisSettings.GetAll();

            Assert.AreEqual("TestSetting1Value", result["TestSetting1"]);
            Assert.AreEqual("TestSetting2Value", result["TestSetting2"]);
        }
    }
}
