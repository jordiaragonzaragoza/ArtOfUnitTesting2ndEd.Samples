namespace Chapter3.LogAn
{
    public class LogAnalyzerUsingExtractedMethod
    {
        public bool IsValidLogFileName(string fileName)
        {
            return this.IsValid(fileName);
        }

        protected virtual bool IsValid(string fileName)
        {
            var fileExtensionManager = new FileExtensionManager();
            return fileExtensionManager.IsValid(fileName);
        }
    }
}
