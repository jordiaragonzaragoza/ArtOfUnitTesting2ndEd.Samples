using Chapter5.LogAn;

namespace Chapter5.LogAn.Tests
{
    public class FakeWebService : IWebService
    {
        public string MessageToWebService;

        public void Write(string message)
        {
            MessageToWebService = message;
        }

        public void Write(ErrorInfo message)
        {
        }
    }
 }