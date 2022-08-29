using Moq;
using NSubstitute;
using NUnit.Framework;
using System;

namespace Chapter5.LogAn.Tests
{
    /// <summary>
    /// Event Related Tests.
    /// </summary>
    [TestFixture]
    public class PresenterTests
    {
        [Test]
        public void ctor_WhenViewIsLoaded_CallsViewRender()
        {
            var mockView = Substitute.For<IView>();

            var presenter = new Presenter(mockView, Substitute.For<ILogger>());
            mockView.Loaded += Raise.Event<Action>();

            mockView.Received().Render(Arg.Is<string>(s => s.Contains("Hello World")));
        }

        [Test]
        public void ctor_WhenViewhasError_CallsLogger()
        {
            var stubView = Substitute.For<IView>();
            var mockLogger = Substitute.For<ILogger>();

            var presenter = new Presenter(stubView, mockLogger);
            stubView.ErrorOccured += Raise.Event<Action<string>>("fake error");

            mockLogger.Received().LogError(Arg.Is<string>(s => s.Contains("fake error")));
        }

        [Test]
        public void ctor_WhenViewhasError_CallsLoggerWithMoq()
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