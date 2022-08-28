using System.IO;

namespace Chapter3.LogAn
{
    public class LogAnalyzerUsingExtensionManagerFactory
    {
        private IExtensionManager manager;
        public LogAnalyzerUsingExtensionManagerFactory()
        {
            manager = ExtensionManagerFactory.Create();
        }
        public bool IsValidLogFileName(string fileName)
        {
            return manager.IsValid(fileName)
            && Path.GetFileNameWithoutExtension(fileName).Length > 5;
        }
    }
}
