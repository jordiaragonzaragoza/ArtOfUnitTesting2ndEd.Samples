using NSubstitute;
using NUnit.Framework;

namespace Chapter5.LogAn.Tests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        /// <summary>
        /// Asserting against a handwritten fake object.
        /// </summary>
        [TestFixture]
        public class TestsWithoutAnIsolationFramework
        {
            [Test]
            public void Analyze_TooShortFileName_CallLogger()
            {
                var fakeLogger = new FakeLogger();

                var analyzer = new LogAnalyzer(fakeLogger);

                analyzer.MinNameLength = 6;
                analyzer.Analyze("a.txt");

                StringAssert.Contains("too short", fakeLogger.LastError);
            }
        }

        /// <summary>
        /// Faking an object using NSub.
        /// </summary>
        [Test]
        public void Analyze_TooShortFileName_CallLogger()
        {
            ILogger logger = Substitute.For<ILogger>();
            var analyzer = new LogAnalyzer(logger);
            analyzer.MinNameLength = 6;

            analyzer.Analyze("a.txt");

            logger.Received().LogError("Filename too short: a.txt");
        }

        [Test]
        public void Analyze_TooShortFileName_CallLoggerArgMatchers()
        {
            ILogger logger = Substitute.For<ILogger>();
            var analyzer = new LogAnalyzer(logger)
            {
                MinNameLength = 6
            };

            analyzer.Analyze("a.txt");

            logger.Received().LogError(Arg.Is<string>(s => s.Contains("too short")));
        }
    }
}
