using Chapter5.LogAn;
using NSubstitute;
using NUnit.Framework;
using System;

namespace NSubExamples
{
    [TestFixture]
    public class NSubBasics
    {
        /// <summary>
        /// Basic use of NSubstitute
        /// </summary>
        [Test]
        public void SubstituteFor_ForInterfaces_ReturnsAFakeInterface()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            Assert.That(fakeRules.IsValidLogFileName("something.bla"), Is.False);
        }

        /// <summary>
        /// Returning a value from a fake object.
        /// </summary>
        [Test]
        public void Returns_ByDefault_WorksForHardCodedArgument()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.IsValidLogFileName("file.name").Returns(true);

            Assert.That(fakeRules.IsValidLogFileName("file.name"), Is.True);
        }

        /// <summary>
        /// Returning a value from a fake object passing any string as argument.
        /// </summary>
        [Test]
        public void Returns_ArgAny_IgnoresArgument()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.IsValidLogFileName(Arg.Any<string>()).Returns(true);
              
            Assert.That(fakeRules.IsValidLogFileName("anything, really!"), Is.True);
        }

        /// <summary>
        /// Simulate an exception
        /// </summary>
        /// <exception cref="Exception"></exception>
        [Test]
        public void Returns_ArgAny_Throws()
        {
            IFileNameRules fakeRules = Substitute.For<IFileNameRules>();

            fakeRules.When(x => x.IsValidLogFileName(Arg.Any<string>()))
                     .Do(x => { throw new Exception("fake exception"); });


            Assert.Throws<Exception>(() => fakeRules.IsValidLogFileName("anything"));

        }
       
        [Test]
        public void RecursiveFakes_work()
        {
            IPerson person = Substitute.For<IPerson>();

            Assert.IsNotNull(person.GetManager());
            Assert.IsNotNull(person.GetManager().GetManager());
            Assert.IsNotNull(person.GetManager().GetManager().GetManager());
        }

        public interface IPerson
        {
            IPerson GetManager();
        }
    }
}
