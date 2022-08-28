using Chapter5.LogAn;
using System;

namespace NSubExamples
{
    public class FakeLogger: ILogger
    {
        public string LastError { get; private set; }
        public Exception WillThrow { get; set; }

        public string LoggerGotMessage { get; private set; }

        public void LogError(string message)
        {
            LoggerGotMessage = message;

            if (WillThrow != null)
            {
                throw WillThrow;
            }

            LastError = message;
        }
    }
}
