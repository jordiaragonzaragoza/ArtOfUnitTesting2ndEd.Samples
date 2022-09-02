using Chapter7.StringParserExample;
using NUnit.Framework;

namespace Chapter7.Tests.StringParserGenericsExampleTests
{
    /// <summary>
    /// An example of a test inheriting from a Generic Base Class.
    /// </summary>
    [TestFixture]
    public class StandardParserGenericTests : GenericParserTests<StandardStringParser>
    {
        protected override string GetInputHeaderSingleDigit()
        {
            return "header\tversion=1\t\n";
        }
    }
}