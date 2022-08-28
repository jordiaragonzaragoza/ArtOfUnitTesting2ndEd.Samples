namespace Chapter4.LogAn.Tests
{
    public class EmailInfo
    {
        public EmailInfo(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }

        public string Body { get;  private init; }

        public string To { get; private init; }
        
        public string Subject { get; private init; }
    }
}
