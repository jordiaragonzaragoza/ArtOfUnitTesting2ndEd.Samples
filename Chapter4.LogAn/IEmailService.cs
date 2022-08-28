namespace Chapter4.LogAn
{
    public interface IEmailService
    {
        public void SendEmail(string to, string subject, string body);
    }
}
