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
