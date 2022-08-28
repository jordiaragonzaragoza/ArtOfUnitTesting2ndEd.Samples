namespace Chapter4.LogAn.Tests
{
    internal class FakeEmailServiceUsingEmailInfo : IEmailService
    {
        public EmailInfo EmailInfo { get; set; }

        public void SendEmail(string to, string subject, string body)
        {
        }
    }
}
