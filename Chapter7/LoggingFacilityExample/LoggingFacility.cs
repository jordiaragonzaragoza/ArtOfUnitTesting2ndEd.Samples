namespace Chapter7.LoggingFacilityExample
{
    public static class LoggingFacility
    {
        public static void Log(string text)
        {
            Logger.Log(text);
        }

        public static ILogger Logger { get; set; }
    }
}