﻿namespace Chapter4.LogAn
{
    public interface IEmailService
    {
        void SendEmail(string to, string subject, string body);
    }
}
