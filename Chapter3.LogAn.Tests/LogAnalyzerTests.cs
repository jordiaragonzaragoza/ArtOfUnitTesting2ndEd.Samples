using NUnit.Framework;
using System;

namespace Chapter3.LogAn.Tests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_NameSupportedExtension_ReturnsTrue()
        {
            var myFakeManager = new FakeExtensionManager
            {
                WillBeValid = true
            };
            var log = new LogAnalyzer(myFakeManager);

            bool result = log.IsValidLogFileName("short.ext");

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsValidFileName_ExtManagerThrowsException_ReturnsFalse()
        {
            var myFakeManager = new FakeExtensionManager
            {
                WillBeValid = true,
                WillThrow = new Exception("this is fake"),
            };
            var log = new LogAnalyzer(myFakeManager);

            bool result = log.IsValidLogFileName("anything.anyextension");
            
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsValidFileName_SupportedExtension_ReturnsTrue()
        {
            var log = new LogAnalyzer(null);
            var myFakeManager = new FakeExtensionManager
            {
                WillBeValid = true
            };
            log.ExtensionManager = myFakeManager;
            
            bool result = log.IsValidLogFileName("short.ext");

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsValidFileName_SupportedExtensionSettingFactory_ReturnsTrue()
        {
            var myFakeManager = new FakeExtensionManager
            {
                WillBeValid = true
            };
            ExtensionManagerFactory.SetManager(myFakeManager);
            var log = new LogAnalyzerUsingExtensionManagerFactory();

            bool result = log.IsValidLogFileName("anything.ext");

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsValidLogFileName_OverrideTest_ReturnsTrue()
        {
            var stub = new FakeExtensionManager
            {
                WillBeValid = true
            };
            var logan = new TestableLogAnalyzerUsingFactoryMethod(stub);
            bool result = logan.IsValidLogFileName("file.ext");
            
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsValidLogFileName_OverrideTestWithoutStub_ReturnsTrue()
        {
            var logan = new TestableLogAnalyzerUsingExtractedMethod
            {
                IsSupported = true
            };

            bool result = logan.IsValidLogFileName("file.ext");

            Assert.That(result, Is.True);
        }
    }
}
