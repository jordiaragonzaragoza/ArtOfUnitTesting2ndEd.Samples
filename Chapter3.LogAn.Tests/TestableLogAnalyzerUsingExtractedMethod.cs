using System.Runtime.Intrinsics.X86;

namespace Chapter3.LogAn.Tests
{
    public class TestableLogAnalyzerUsingExtractedMethod : LogAnalyzerUsingExtractedMethod
    {
        public bool IsSupported;

        // It breaks some serious object-oriented principles,
        // especially the idea of encapsulation, which says,
        // “Hide everything that the user of your class doesn’t need to see.”
        protected override bool IsValid(string fileName)
        {
            return IsSupported;
        }
    }
}
