namespace Chapter7.StringParserExample
{
    public class IISLogStringParser : BaseStringParser
    {
        public IISLogStringParser(string toParse)
            : base(toParse)
        {
        }

        public override bool HasCorrectHeader()
        {
            if (!string.IsNullOrEmpty(BaseStringParser.GetBetween(this.StringToParse, "header;version=", ";\n")))
            {
                return true;
            }

            return false;
        }

        public override string GetStringVersionFromHeader()
        {
            return BaseStringParser.GetBetween(this.StringToParse, "header;version=", ";\n");
        }
    }
}
