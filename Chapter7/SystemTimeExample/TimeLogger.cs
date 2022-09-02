namespace Chapter7.SystemTimeExample
{
    public static class TimeLogger
    {
        public static string CreateMessage(string info)
        {
            return SystemTime.Now.ToShortDateString() + " " + info;
        }
    }
}
