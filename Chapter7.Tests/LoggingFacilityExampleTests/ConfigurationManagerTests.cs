using Chapter7.LoggingFacilityExample;
using NSubstitute;
using NUnit.Framework;
using System;

namespace Chapter7.Tests.LoggingFacilityExampleTests
{
    [TestFixture]
    public class ConfigurationManagerTests
    {
        [Test]
        public void Analyze_EmptyFile_ThrowsException()
        {
            LoggingFacility.Logger = Substitute.For<ILogger>();

            var ex = Assert.Throws<ArgumentException>(() => ConfigurationManager.IsConfigured(""));

            Assert.That(ex.Message, Does.Contain("config name has to be provided"));
        }

        [TearDown]
        public void TearDown()
        {
            // need to reset a static resource between tests
            LoggingFacility.Logger = null;
        }
    }

}
