using System;
using Chapter7.SystemTimeExample;
using NUnit.Framework;

namespace Chapter7.Tests.SystemTimeExampleTests
{
    [TestFixture]
    public class SystemTimeTests
    {
        [Test]
        public void SettingSystemTime_Always_ChangesTime()
        {
            var dateTime = new DateTime(2000, 1, 1);
            SystemTime.Set(dateTime);
            var expectedTime = dateTime.ToShortDateString();

            string output = TimeLogger.CreateMessage("a");

            StringAssert.Contains(expectedTime, output);
        }

        [TearDown]
        public void AfterEachTest()
        {
            SystemTime.Reset();
        }
    }
}
