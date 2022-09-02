using Chapter7.LoggingFacilityExample;
using NUnit.Framework;
using System;

namespace Chapter7.Tests.LoggingFacilityExampleTests
{
    [TestFixture]
    public class LogAnalyzerWithBaseTests : BaseFakeLoggerTests
    {
        [Test]
        public void Analyze_EmptyFile_ThrowsException()
        {
            FakeTheLogger();

            var ex = Assert.Throws<ArgumentException>(() => LogAnalyzer.Analyze(""));

            Assert.That(ex.Message, Does.Contain("filename has to be provided"));
        }
    }
}
