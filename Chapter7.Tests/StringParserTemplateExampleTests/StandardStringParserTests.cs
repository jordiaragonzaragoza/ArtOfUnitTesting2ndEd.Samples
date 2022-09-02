using Chapter7.StringParserExample;
using NUnit.Framework;

namespace Chapter7.Tests.StringParserTemplateExampleTests
{
    [TestFixture]
    public class StandardStringParserTests : BaseStringParserTests
    {
        protected static IStringParser GetParser(string input)
        {
            return new StandardStringParser(input);
        }

        [Test]
        public override void TestGetStringVersionFromHeader_SingleDigit_Found()
        {
            IStringParser parser = GetParser("header\tversion=1\t\n");

            string versionFromHeader = parser.GetStringVersionFromHeader();

            Assert.That(versionFromHeader, Is.EqualTo("1"));
        }

        [Test]
        public override void TestGetStringVersionFromHeader_WithMinorVersion_Found()
        {
            IStringParser parser = GetParser("header\tversion=1.1\t\n");

            string versionFromHeader = parser.GetStringVersionFromHeader();

            Assert.That(versionFromHeader, Is.EqualTo("1.1"));
        }

        [Test]
        public override void TestGetStringVersionFromHeader_WithRevision_Found()
        {
            IStringParser parser = GetParser("header\tversion=1.1.1\t\n");

            string versionFromHeader = parser.GetStringVersionFromHeader();

            Assert.That(versionFromHeader, Is.EqualTo("1.1.1"));
        }
    }
}