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
	public partial class SettingsView : ContentPage
	{
        UsersInMemoryService usersInMemoryService;
        AppSettingsInMemoryService appSettingsInMemoryService;

        public SettingsView ()
		{
			InitializeComponent ();
            appSettingsInMemoryService = new AppSettingsInMemoryService();
            usersInMemoryService = new UsersInMemoryService();
        }

        protected async override void OnAppearing()
        {
            var settings = await appSettingsInMemoryService.GetSettings();
            swEnableListSharing.On = settings.EnableListSharing;
            swEnableNotifications.On = settings.EnableNotifications;

            var currentUser = await usersInMemoryService.GetUserById(settings.CurrentUserId);
            txtUserName.Text = currentUser.UserName;
            txtEmail.Text = currentUser.Email;

            base.OnAppearing();
        }

        private async void btnSaveSettings_Clicked(object sender, EventArgs e)
        {
            var currentSettings = await appSettingsInMemoryService.GetSettings();
            currentSettings.EnableListSharing = swEnableListSharing.On;
            currentSettings.EnableNotifications = swEnableNotifications.On;
            await appSettingsInMemoryService.SaveSettings(currentSettings);

            var user = await usersInMemoryService.GetUserById(currentSettings.CurrentUserId);
            user.UserName = txtUserName.Text.Trim();
            user.Email = txtEmail.Text.Trim();
            await usersInMemoryService.SaveUser(user);

            await Navigation.PopAsync();
        }
    }
}