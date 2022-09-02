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

        protected static string GetBetween(string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                int Start, End;
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }

            return string.Empty;
        }
    }
}
