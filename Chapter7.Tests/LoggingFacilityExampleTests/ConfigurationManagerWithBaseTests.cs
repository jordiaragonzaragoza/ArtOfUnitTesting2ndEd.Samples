using Chapter7.LoggingFacilityExample;
using NUnit.Framework;
using System;

namespace Chapter7.Tests.LoggingFacilityExampleTests
{
    [TestFixture]
    public class ConfigurationManagerWithBaseTests : BaseFakeLoggerTests
    {
        [Test]
        public void Analyze_EmptyFile_ThrowsException()
        {
            FakeTheLogger();

            var ex = Assert.Throws<ArgumentException>(() => ConfigurationManager.IsConfigured(""));

            Assert.That(ex.Message, Does.Contain("config name has to be provided"));
        }
    }

}
