﻿using Moq;
using NUnit.Framework;

namespace Chapter5.LogAn.Tests
{
    [TestFixture]
    public class OtherFrameworks
    {
        [Test]
        public void ctor_WhenViewhasError_CallsLogger()
        {
            var stubView = new Mock<IView>();
            var mockLogger = new Mock<ILogger>();

            var p = new Presenter(stubView.Object, mockLogger.Object);
            stubView.Raise(view => view.ErrorOccured += null, "fake error");

            mockLogger.Verify(logger => 
                logger.LogError(It.Is<string>(s => s.Contains("fake error"))));

        }
    }
}