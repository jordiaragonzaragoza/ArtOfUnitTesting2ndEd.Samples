namespace Chapter3.LogAn
{
    public class LogAnalyzer
    {
        private IExtensionManager manager;
        public LogAnalyzer(IExtensionManager mgr)
        {
            manager = mgr;
        }

        public IExtensionManager ExtensionManager
        {
            get 
            { 
                return manager; 
            }

            set 
            {
                manager = value; 
            }
        }

        public bool IsValidLogFileName(string fileName)
        {
            bool result = false;
            try
            {
                result = manager.IsValid(fileName);
            }
            catch 
            {
                return result;
            }
            

            return result;
        }
    }
}
