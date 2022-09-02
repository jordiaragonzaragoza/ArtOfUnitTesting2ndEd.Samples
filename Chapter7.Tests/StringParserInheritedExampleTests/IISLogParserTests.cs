using Chapter7.StringParserExample;
using NUnit.Framework;

namespace Chapter7.Tests.StringParserInheritedExampleTests
{
    [TestFixture]
    public class IISLogParserTests : FillInTheBlanksStringParserTests
    {
        protected override IStringParser GetParser(string input)
        {
            return new IISLogStringParser(input);
        }

        protected override string HeaderVersion_SingleDigit
        {
            get
            {
                return "header;version=1;\n";
            }
        }

        protected override string HeaderVersion_WithMinorVersion
        {
            get
            {
                return "header;version=1.1;\n";
            }
        }

        protected override string HeaderVersion_WithRevision
        {
            get
            {
                return "header;version=1.1.1;\n";
            }
        }

        [Test]
        public void ExtraTestForGoodMeasure()
        {
            //some test that is specific for this class
        }
    }
}
