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
            if (!string.IsNullOrEmpty(BaseStringParser.GetBetween(this.StringToParse, "<Header><Version>", "<Version></Header>")))
            {
                return true;
            }

            return false;
        }

        public override string GetStringVersionFromHeader()
        {
            return BaseStringParser.GetBetween(this.StringToParse, "<Header><Version>", "<Version></Header>");
        }
    }
}
