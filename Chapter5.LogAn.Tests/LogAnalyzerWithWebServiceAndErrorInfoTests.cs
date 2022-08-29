using System;
using NSubstitute;
using NUnit.Framework;

namespace Chapter5.LogAn.Tests
{
    [TestFixture]
    internal class LogAnalyzerWithWebServiceAndErrorInfoTests
    {
        [Test]
        public void Analyze_LoggerThrows_CallsWebServiceWithNSubObject()
        {
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();
            stubLogger.When(logger => logger.LogError(Arg.Any<string>()))
                .Do(info => { throw new Exception("fake exception"); });
            var analyzer = new LogAnalyzerWithWebServiceAndErrorInfo(stubLogger, mockWebService)
            {
                MinNameLength = 10
            };

            analyzer.Analyze("Short.txt");

            mockWebService.Received()
             .Write(Arg.Is<ErrorInfo>(info => info.Severity == 1000
                 && info.Message.Contains("fake exception")));
        }

        [Test]
        public void Analyze_LoggerThrows_CallsWebServiceWithNSubObjectCompare()
        {
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();
            stubLogger.When(
                logger => logger.LogError(Arg.Any<string>()))
                .Do(info => { throw new Exception("fake exception"); });
            var analyzer = new LogAnalyzerWithWebServiceAndErrorInfo(stubLogger, mockWebService)
            {
                MinNameLength = 10
            };
            var expected = new ErrorInfo(1000, "fake exception");

            analyzer.Analyze("Short.txt");


            mockWebService.Received().Write(expected);
        }
    }
}



