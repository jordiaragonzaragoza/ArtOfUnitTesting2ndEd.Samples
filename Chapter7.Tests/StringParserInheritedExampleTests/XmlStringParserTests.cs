using Chapter7.StringParserExample;
using NUnit.Framework;

namespace Chapter7.Tests.StringParserInheritedExampleTests
{
    [TestFixture]
    public class XMLStringParserTests : FillInTheBlanksStringParserTests
    {
        protected override string HeaderVersion_SingleDigit
        {
            get
            {
                return string.Format("<Header><Version>{0}<Version></Header>", EXPECTED_SINGLE_DIGIT);
            }
        }

        protected override string HeaderVersion_WithMinorVersion
        {
            get
            {
                return string.Format("<Header><Version>{0}<Version></Header>", EXPECTED_WITH_MINORVERSION); ;
            }
        }

        protected override string HeaderVersion_WithRevision
        {
            get
            {
                return string.Format("<Header><Version>{0}<Version></Header>", EXPECTED_WITH_REVISION);
            }
        }

        protected override IStringParser GetParser(string input)
        {
            return new XMLStringParser(input);
        }
    }
}
