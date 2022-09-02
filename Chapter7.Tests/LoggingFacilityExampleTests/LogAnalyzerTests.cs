using Chapter7.LoggingFacilityExample;
using NSubstitute;
using NUnit.Framework;
using System;

namespace Chapter7.Tests.LoggingFacilityExampleTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void Analyze_EmptyFile_ThrowsException()
        {
            LoggingFacility.Logger = Substitute.For<ILogger>();

            var ex = Assert.Throws<ArgumentException>(() => LogAnalyzer.Analyze(""));

            Assert.That(ex.Message, Does.Contain("filename has to be provided"));
        }

        [TearDown]
        public void teardown()
        {
            // need to reset a static resource between tests
            LoggingFacility.Logger = null;
        }
    }
}
