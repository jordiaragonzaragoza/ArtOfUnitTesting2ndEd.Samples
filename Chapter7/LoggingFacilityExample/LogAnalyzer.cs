using System;

namespace Chapter7.LoggingFacilityExample
{
    /// <summary>
    /// This class uses the LoggingFacility Internally.
    /// </summary>
    public class LogAnalyzer
    {
        public static void Analyze(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("filename has to be provided");
            }

            if (fileName.Length < 8)
            {
                LoggingFacility.Log("Filename too short:" + fileName);
            }
        }
    }
}