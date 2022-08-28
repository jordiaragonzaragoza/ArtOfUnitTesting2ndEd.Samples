using System;

namespace Chapter3.LogAn.Tests
{
    public class FakeExtensionManager : IExtensionManager
    {
        public bool WillBeValid { get; set; }

        public Exception WillThrow { get; set; }
        public bool IsValid(string fileName)
        {
            if (WillThrow != null)
            { 
                throw WillThrow; 
            }

            return WillBeValid;
        }
    }
}
