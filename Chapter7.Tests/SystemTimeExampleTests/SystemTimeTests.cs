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
            SystemTime.Set(new DateTime(2000, 1, 1));

            string output = TimeLogger.CreateMessage("a");

            StringAssert.Contains("01/01/2000", output);
        }

        [TearDown]
        public void AfterEachTest()
        {
            SystemTime.Reset();
        }
    }
}
