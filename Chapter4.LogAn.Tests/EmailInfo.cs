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

        public string Body { get; set; }

        public string To { get; set; }
        
        public string Subject { get; set; }
    }
}
