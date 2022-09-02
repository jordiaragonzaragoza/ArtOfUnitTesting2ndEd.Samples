namespace Chapter7.StringParserExample
{
    public class StandardStringParser : BaseStringParser
    {
        public StandardStringParser(string toParse)
            : base(toParse)
        {
        }

        public override bool HasCorrectHeader()
        {
            if (!string.IsNullOrEmpty(BaseStringParser.GetBetween(this.StringToParse, "header\tversion=", "\t\n")))
            {
                return true;
            }

            return false;
        }

        public override string GetStringVersionFromHeader()
        {
            return BaseStringParser.GetBetween(this.StringToParse, "header\tversion=", "\t\n");
        }
    }
}
