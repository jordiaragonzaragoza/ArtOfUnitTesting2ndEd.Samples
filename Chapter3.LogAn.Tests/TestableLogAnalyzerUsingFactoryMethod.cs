namespace Chapter3.LogAn.Tests
{
    public class TestableLogAnalyzerUsingFactoryMethod : LogAnalyzerUsingFactoryMethod
    {
        private IExtensionManager manager;

        public TestableLogAnalyzerUsingFactoryMethod(IExtensionManager mgr)
        {
            manager = mgr;
        }

        
        protected override IExtensionManager GetManager()
        {
            return manager;
        }
    }
}
