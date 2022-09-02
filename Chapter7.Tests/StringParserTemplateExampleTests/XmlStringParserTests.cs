using Chapter7.StringParserExample;
using NUnit.Framework;

namespace Chapter7.Tests.StringParserTemplateExampleTests
{
    [TestFixture]
    public class XmlStringParserTests : BaseStringParserTests
    {
        protected static IStringParser GetParser(string input)
        {
            return new XMLStringParser(input);
        }

        [Test]
        public override void TestGetStringVersionFromHeader_SingleDigit_Found()
        {
            IStringParser parser = GetParser("<Header><Version>1<Version></Header>");

            string versionFromHeader = parser.GetStringVersionFromHeader();
            Assert.That(versionFromHeader, Is.EqualTo("1"));
        }

        [Test]
        public override void TestGetStringVersionFromHeader_WithMinorVersion_Found()
        {
            IStringParser parser = GetParser("<Header><Version>1.1<Version></Header>");

            string versionFromHeader = parser.GetStringVersionFromHeader();

            Assert.That(versionFromHeader, Is.EqualTo("1.1"));
        }

        [Test]
        public override void TestGetStringVersionFromHeader_WithRevision_Found()
        {
            IStringParser parser = GetParser("<Header><Version>1.1.1<Version></Header>");

            string versionFromHeader = parser.GetStringVersionFromHeader();

            Assert.That(versionFromHeader, Is.EqualTo("1.1.1"));
        }
    }
}