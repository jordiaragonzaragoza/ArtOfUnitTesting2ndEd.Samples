using NUnit.Framework;

namespace Chapter5.LogAn.Tests
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

            analyzer.MinNameLength= 6;
            analyzer.Analyze("a.txt");

            StringAssert.Contains("too short",fakeLogger.LastError);
        }
    }
}
