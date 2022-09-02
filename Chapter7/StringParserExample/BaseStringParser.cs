namespace Chapter7.StringParserExample
{
    public abstract class BaseStringParser : IStringParser
    {
        private readonly string stringToParse;

        public string StringToParse
        {
            get { return stringToParse; }
        }

        protected BaseStringParser(string filename)
        {
            this.stringToParse = filename;
        }

        public abstract bool HasCorrectHeader();

        public abstract string GetStringVersionFromHeader();
    }
}
