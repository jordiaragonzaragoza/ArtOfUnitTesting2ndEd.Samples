using System;

namespace Chapter5.LogAn
{
    public class LogAnalyzerWithWebService
    {
        private ILogger _logger;
        private IWebService _webService;

        public LogAnalyzerWithWebService(ILogger logger,IWebService webService)
        {
            _logger = logger;
            _webService = webService;
        }

        public int MinNameLength { get; set; }

        public void Analyze(string filename)
        {
            if (filename.Length<MinNameLength)
            {
                try
                {
                    _logger.LogError(string.Format("Filename too short: {0}",filename));
                }
                catch (Exception e)
                {
                    _webService.Write("Error From Logger: " + e);
                }
            }
        }
    }
}
