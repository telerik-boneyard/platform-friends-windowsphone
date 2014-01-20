using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telerik.Windows.Controls.Cloud.Sample
{
    /// <summary>
    /// Contains properties used to initialize the Everlive and EQATEC connections.
    /// </summary>
    public static class ConnectionSettings
    {   
        /// <summary> 
        /// Input your API key below to connect to your own app. 
        /// </summary> 
        public static string EverliveApiKey = "your-api-key-here";

        /// <summary>
        /// The EQATEC product identifier.
        /// </summary>
        public static string EqatecProductId = "your-eqatec-id-here";

        /// <summary> 
        /// Specified whether to use HTTPS when communicating with Everlive. 
        /// </summary> 
        public static bool EverliveUseHttps = false;
    }
}
