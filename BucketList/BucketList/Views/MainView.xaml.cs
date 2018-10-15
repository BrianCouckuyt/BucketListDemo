using BucketList.Domain.Models;
using BucketList.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BucketList.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainView : ContentPage
	{
        BucketsInMemoryService bucketsInMemoryService;
        AppSettingsInMemoryService appSettingsInMemoryService;

		public MainView ()
		{
			InitializeComponent ();
            appSettingsInMemoryService = new AppSettingsInMemoryService();
            bucketsInMemoryService = new BucketsInMemoryService();
		}

        private async void btnAddBucketList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BucketsView());
        }

        private async void btnSettings_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsView());
        }

        private async Task RefreshBucketLists()
        {
            var settings = await appSettingsInMemoryService.GetSettings();
            var buckets = await bucketsInMemoryService.GetBucketListsForUser(settings.CurrentUserId);
            lvBucketLists.ItemsSource = buckets;
        }

        protected async override void OnAppearing()
        {
            await RefreshBucketLists();
            base.OnAppearing();
        }

        private async void lvBucketLists_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var bucket = e.Item as Bucket;
            if(bucket != null)
            {
                await DisplayAlert("Tap!", $"Congratulations! You tapped {bucket.Title}", "uh, ok...");
                await Navigation.PushAsync(new BucketsView());
            }

        }
    }
}