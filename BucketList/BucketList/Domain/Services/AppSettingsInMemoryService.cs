using BucketList.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BucketList.Domain.Services
{
    public class AppSettingsInMemoryService
    {
        private static AppSettings currentSettings = new AppSettings
        {
            CurrentUserId = Guid.Empty,
            EnableListSharing = true,
            EnableNotifications = false
        };

        public async Task<AppSettings> GetSettings()
        {
            await Task.Delay(Constants.Mocking.FakeDelay);
            return currentSettings;
        }

        public async Task SaveSettings(AppSettings newSettings)
        {
            await Task.Delay(Constants.Mocking.FakeDelay);
            currentSettings = newSettings;
        }
    }
}
