namespace Chapter7.StringParserExample
{
    public interface IStringParser
    {
        public string StringToParse { get; }

        public bool HasCorrectHeader();

        public string GetStringVersionFromHeader();
    }
}