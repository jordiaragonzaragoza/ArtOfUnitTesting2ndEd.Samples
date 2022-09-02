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
            //missing here: real implementation
            return false;
        }

        public override string GetStringVersionFromHeader()
        {
            //missing here: real implementation
            return string.Empty;
        }
    }
}
