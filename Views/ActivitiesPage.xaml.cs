using System;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Telerik.Windows.Controls.Cloud.Sample.Models;
using Telerik.Windows.Controls.Cloud.Sample.Helpers;
using Telerik.Windows.Cloud;

namespace Telerik.Windows.Controls.Cloud.Sample.Views
{
    public partial class ActivitiesPage : PhoneApplicationPage
    {
        public ActivitiesPage()
        {
            InitializeComponent();
            EverliveCloudDataService<Activity> cds = new EverliveCloudDataService<Activity>();
            cds.Filter = activity => activity.UserId == CloudProvider.Current.CurrentUser.GetId();
            this.activities.CloudDataService = cds;
            //activities.ItemsType = typeof(Activity);
            //activities.Sorting = new SortingDefinition("CreatedAt", OrderByDirection.Descending);
        }

        private void StackPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            var activity = (Activity)((FrameworkElement)e.OriginalSource).DataContext;
            NavigationService.Navigate("/Views/ViewActivityPage.xaml", activity);
        }

        private void AddActivityButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate("/Views/CreateOrEditActivityPage.xaml", new Activity());
        }

        private void RefreshActiviesButton_Click(object sender, EventArgs e)
        {
            this.activities.ReloadCloudItemsAsync();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.NavigationMode != NavigationMode.New)
            {
                this.activities.ReloadCloudItemsAsync();
            }
        }
    }
}