using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Telerik.Windows.Controls.Cloud.Sample.Models;

namespace Telerik.Windows.Controls.Cloud.Sample.Views
{
    public partial class LoginPage : PhoneApplicationPage
    {
        private LoginProvider? lastProvider;
        public LoginPage()
        {
            InitializeComponent();
        }

        private void loginControl_Success(object sender, EventArgs e)
        {
            App.Analytics.TrackFeatureStop("Login." + this.GetLoginFeatureName(this.lastProvider));
        }

        private void loginControl_LoggingIn(object sender, LoginEventArgs e)
        {
            this.lastProvider = e.Provider;
            App.Analytics.TrackFeatureStart("Login." + this.GetLoginFeatureName(this.lastProvider));
        }

        private string GetLoginFeatureName(LoginProvider? provider)
        {
            if (provider == null)
            {
                return "Regular";
            }
            string providerName = provider.Value.ToString();

            return providerName;
        }
    }
}