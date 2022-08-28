using NSubstitute;
using NUnit.Framework;
using System;

namespace Chapter5.LogAn.Tests
{
    [TestFixture]
    internal class LogAnalyzerTestsWithNSubstitute
    {
        [Test]
        public void Analyze_LoggerThrows_CallsWebService()
        {
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();
            stubLogger.When(logger => logger.LogError(Arg.Any<string>()))
                .Do(info => { throw new Exception("fake exception"); });

            LogAnalyzerWithWebService analyzer = new LogAnalyzerWithWebService(stubLogger, mockWebService);

            analyzer.MinNameLength = 10;
            analyzer.Analyze("Short.txt");

            mockWebService.Received()
                .Write(Arg.Is<string>(s => s.Contains("fake exception")));

        }
    }
}
  


