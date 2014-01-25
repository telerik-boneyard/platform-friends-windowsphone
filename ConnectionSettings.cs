using System;

namespace Telerik.Windows.Controls.Cloud.Sample
{
    /// <summary>
    /// Contains properties used to initialize the Backend Services and Analytics connections.
    /// </summary>
    public static class ConnectionSettings
    {
        /// <summary> 
        /// Input your Backend Services API key below to connect to your own app. 
        /// </summary> 
        public static string EverliveApiKey = "hNCCe5CHUKCkwvhO";

        /// <summary>
        /// The Telerik Analytics project identifier.
        /// </summary>
        public static string AnalyticsProjectKey = "5f6f78c67d6c4acb92a0b06c30de518e";

        /// <summary> 
        /// Specified whether to use HTTPS when communicating with Backend Services. 
        /// </summary> 
        public static bool EverliveUseHttps = false;

        public static void ThrowError()
        {
            throw new ArgumentException("Please enter your Backend Services project API key");
        }
    }
}
