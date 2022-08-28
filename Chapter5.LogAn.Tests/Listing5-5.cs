using NSubstitute;
using NUnit.Framework;
using System;

namespace Chapter5.LogAn.Tests
{
    [TestFixture]
    public class LogAnalyzerTestsWithHandWrittenFakes
    {
        [Test]
        public void Analyze_LoggerThrows_CallsWebService()
        {
            var mockWebService = new FakeWebService();
            var stubLogger = new FakeLogger
            {
                WillThrow = new Exception("fake exception")
            };
            LogAnalyzerWithWebService analyzer = new LogAnalyzerWithWebService(stubLogger, mockWebService)
            {
                MinNameLength = 8
            };
            var tooShortFileName="abc.ext";

            analyzer.Analyze(tooShortFileName);

            Assert.That(mockWebService.MessageToWebService, Does.Contain("fake exception"));
        }

        [Test]
        public void Analyze_LoggerThrows_CallsWebServiceWithNSub()
        {
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();
            stubLogger.When( 
                logger => logger.LogError(Arg.Any<string>()))
                .Do(info => { throw new Exception("fake exception");});

            var analyzer = new LogAnalyzerWithWebService(stubLogger, mockWebService)
            {
                MinNameLength = 10
            };
            analyzer.Analyze("Short.txt");

            mockWebService
                .Received()
                .Write(Arg.Is<string>(s => s.Contains("fake exception")));
        }
        [Test]
        public void Analyze_LoggerThrows_CallsWebServiceWithNSubObject()
        {
            var mockWebService = Substitute.For<IWebService>();
            var stubLogger = Substitute.For<ILogger>();
            stubLogger.When( 
                logger => logger.LogError(Arg.Any<string>()))
                .Do(info => { throw new Exception("fake exception");});

            var analyzer = 
               new LogAnalyzerWithWebServiceAndErrorInfo(stubLogger, mockWebService);

            analyzer.MinNameLength = 10;
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
                .Do(info => { throw new Exception("fake exception");});

            var analyzer = 
               new LogAnalyzerWithWebServiceAndErrorInfo(stubLogger, mockWebService);

            analyzer.MinNameLength = 10;
            analyzer.Analyze("Short.txt");

            var expected = new ErrorInfo(1000, "fake exception");
            mockWebService.Received().Write(expected);
        }
    }
 }


    public interface IPerson
    {
        IPerson GetManager();
    }



