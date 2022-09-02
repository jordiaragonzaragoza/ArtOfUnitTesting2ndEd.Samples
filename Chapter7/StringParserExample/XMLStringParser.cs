using System;

namespace Chapter7.StringParserExample
{
    public class XMLStringParser : BaseStringParser
    {
        public XMLStringParser(string toParse) 
            : base(toParse)
        {
        }

        public override bool HasCorrectHeader()
        {
            //missing here: logic that parses xml
            return false;
        }

        public override string GetStringVersionFromHeader()
        {
            //missing here: logic that parses xml
            return string.Empty;
        }
    }
}
