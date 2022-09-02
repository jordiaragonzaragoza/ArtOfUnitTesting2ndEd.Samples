using Chapter7.LoggingFacilityExample;
using NSubstitute;
using NUnit.Framework;

namespace Chapter7.Tests.LoggingFacilityExampleTests
{
    [TestFixture]
    public class BaseFakeLoggerTests
    {
        public ILogger FakeTheLogger()
        {
            LoggingFacility.Logger = Substitute.For<ILogger>();

            return LoggingFacility.Logger;
        }

        [TearDown]
        public void TearDown()
        {
            // need to reset a static resource between tests
            LoggingFacility.Logger = null;
        }
    }
}