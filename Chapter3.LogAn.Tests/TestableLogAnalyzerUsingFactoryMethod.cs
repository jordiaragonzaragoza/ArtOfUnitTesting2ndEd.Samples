namespace Chapter3.LogAn.Tests
{
    public class TestableLogAnalyzerUsingFactoryMethod : LogAnalyzerUsingFactoryMethod
    {
        public TestableLogAnalyzerUsingFactoryMethod(IExtensionManager mgr)
        {
            Manager = mgr;
        }

        public IExtensionManager Manager;
        
        protected override IExtensionManager GetManager()
        {
            return Manager;
        }
    }
}
