using System;
using Chapter7.StringParserExample;
using NUnit.Framework;

namespace Chapter7.Tests.StringParserInheritedExampleTests
{
    public abstract class FillInTheBlanksStringParserTests
    {
        protected abstract IStringParser GetParser(string input);
        protected abstract string HeaderVersion_SingleDigit { get; }
        protected abstract string HeaderVersion_WithMinorVersion { get; }
        protected abstract string HeaderVersion_WithRevision { get; }
        public const string EXPECTED_SINGLE_DIGIT = "1";
        public const string EXPECTED_WITH_REVISION = "1.1.1";
        public const string EXPECTED_WITH_MINORVERSION = "1.1";


        [Test]
        public void TestGetStringVersionFromHeader_SingleDigit_Found()
        {
            string input = HeaderVersion_SingleDigit;
            IStringParser parser = GetParser(input);

            string versionFromHeader = parser.GetStringVersionFromHeader();

            Assert.That(versionFromHeader, Is.EqualTo(EXPECTED_SINGLE_DIGIT));
        }


        [Test]
        public void TestGetStringVersionFromHeader_WithMinorVersion_Found()
        {
            string input = HeaderVersion_WithMinorVersion;
            IStringParser parser = GetParser(input);

            string versionFromHeader = parser.GetStringVersionFromHeader();

            Assert.That(versionFromHeader, Is.EqualTo(EXPECTED_WITH_MINORVERSION));
        }

        [Test]
        public void TestGetStringVersionFromHeader_WithRevision_Found()
        {
            string input = HeaderVersion_WithRevision;
            IStringParser parser = GetParser(input);

            string versionFromHeader = parser.GetStringVersionFromHeader();

            Assert.That(versionFromHeader, Is.EqualTo(EXPECTED_WITH_REVISION));
        }

    }

    //An example of the same idea using Generics
    public abstract class GenericParserTests<T>
        where T : IStringParser
    {
        protected abstract string GetInputHeaderSingleDigit();

        protected T GetParser(string input)
        {
            return (T)Activator.CreateInstance(typeof(T), input);
        }

        [Test]
        public void GetStringVersionFromHeader_SingleDigit_Found()
        {
            string input = GetInputHeaderSingleDigit();
            T parser = GetParser(input);

            bool result = parser.HasCorrectHeader();

            Assert.That(result, Is.False);
        }


        //more tests
        //...
    }
    //AN example of a test inheriting from a Generic Base Class
    [TestFixture]
    public class StandardParserGenericTests : GenericParserTests<StandardStringParser>
    {
        protected override string GetInputHeaderSingleDigit()
        {
            return "Header;1";
        }
    }
}