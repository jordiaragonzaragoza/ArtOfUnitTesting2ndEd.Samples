using System;

namespace Chapter4.LogAn
{
    public class LogAnalyzer
    {
        private readonly IWebService webService;
        private readonly IEmailService emailService;

        public LogAnalyzer(IWebService webService, IEmailService emailService)
        {
            this.webService = webService;
            this.emailService = emailService;
        }

        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                try
                {
                    webService.LogError("Filename too short:" + fileName);
                }
                catch (Exception e)
                {
                    emailService.SendEmail("someone@somewhere.com", "can’t log", e.Message);
                }
            }
        }
    }
}
