using NUnit.Framework;
using NUnit.Framework.Internal;
using System;

namespace Chapter4.LogAn.Tests
{
    public class LogAnalyzerTests
    {
        [Test]
        public void Analyze_TooShortFileName_CallsWebService()
        {
            var mockService = new FakeWebService();
            var log = new LogAnalyzer(mockService, null);
            var tooShortFileName = "abc.ext";

            log.Analyze(tooShortFileName);

            StringAssert.Contains("Filename too short:abc.ext", mockService.LastError);
        }

        [Test]
        public void Analyze_WebServiceThrows_SendsEmail()
        {
            var stubService = new FakeWebService
            {
                ToThrow = new Exception("fake exception")
            };
            var mockEmail = new FakeEmailService();
            var log = new LogAnalyzer(stubService, mockEmail);
            string tooShortFileName = "abc.ext";

            log.Analyze(tooShortFileName);

            // Several asserts can sometimes be a problem,
            // because the first time a assert fails in your test,
            // it actually throws a special type of exception that is caught by the test runner.
            // That also means no other lines below the line that just failed will be executed.
            // it would be a good indication to you to break this test into multiple tests.
            StringAssert.Contains("someone@somewhere.com", mockEmail.To);
            StringAssert.Contains("fake exception", mockEmail.Body);
            StringAssert.Contains("can’t log", mockEmail.Subject);
        }

        [Test]
        public void Analyze_WebServiceThrowsUsingEmailInfo_SendsEmail()
        {
            var stubService = new FakeWebService
            {
                ToThrow = new Exception("fake exception")
            };
            var expectedEmail = new EmailInfo("someone@somewhere.com", "can’t log", "fake exception");
            var mockEmail = new FakeEmailServiceUsingEmailInfo()
            {
                EmailInfo = expectedEmail,
            };
            var log = new LogAnalyzer(stubService, mockEmail);
            string tooShortFileName = "abc.ext";
            

            log.Analyze(tooShortFileName);

            Assert.That(mockEmail.EmailInfo, Is.SameAs(expectedEmail));
        }
    }
}