using System;

namespace Chapter7.LoggingFacilityExample
{
    /// <summary>
    /// Another class that uses the LoggingFacility internally.
    /// </summary>
    public class ConfigurationManager
    {
        public static bool IsConfigured(string configName)
        {
            if (string.IsNullOrEmpty(configName))
            {
                throw new ArgumentException("config name has to be provided");
            }

            LoggingFacility.Log("checking " + configName);

            return true;
        }
    }
}