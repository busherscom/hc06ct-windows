using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Globalization;
using System.Windows;

namespace HC06CT
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            AppCenter.Start("01c507c9-4f1e-4773-b923-0e23334d5609",
                    typeof(Analytics), typeof(Crashes));
            SetCountryCode();
            Analytics.TrackEvent("Running");
            // AppCenter.LogLevel = LogLevel.Verbose;
            // Crashes.GenerateTestCrash();
            // System.Guid? installId = await AppCenter.GetInstallIdAsync();
            Crashes.NotifyUserConfirmation(UserConfirmation.AlwaysSend);
        }

        private static void SetCountryCode()
        {
            try
            {
                // This fallback country code doesn't reflect the physical device location, but rather the
                // country that corresponds to the culture it uses.
                var countryCode = RegionInfo.CurrentRegion.TwoLetterISORegionName;
                AppCenter.SetCountryCode(countryCode);
            }
            catch (Exception exception)
            {
                Crashes.TrackError(exception);
            }
        }
    }
}