using System;

namespace Chapter4.LogAn.Tests
{
    public class FakeWebService : IWebService
    {
        public string LastError { get; private set; }

        public Exception ToThrow { get; set; }

        public void LogError(string message)
        {
            if (ToThrow != null)
            {
                throw ToThrow;
            }

            LastError = message;
        }
    }
}
