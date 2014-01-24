using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telerik.Windows.Controls.Cloud.Sample
{
    /// <summary>
    /// Contains properties used to initialize the Backend Services and Analytics connections.
    /// </summary>
    public static class ConnectionSettings
    {
        /// <summary> 
        /// Input your API key below to connect to your own app. 
        /// </summary> 
        public static string EverliveApiKey = "74c1j3HHDRBCnghs";

        /// <summary>
        /// The Telerik Analytics project identifier.
        /// </summary>
        public static string AnalyticsProjectKey = "your-Analytics-project-key-here";

        /// <summary> 
        /// Specified whether to use HTTPS when communicating with Everlive. 
        /// </summary> 
        public static bool EverliveUseHttps = false;
       
        public static void ThrowError()
        {
            throw new ArgumentNullException("Please enter your Backend Services project API key");
        }
    }
}
