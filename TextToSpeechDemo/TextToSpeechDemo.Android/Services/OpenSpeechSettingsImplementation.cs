using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TextToSpeechDemo.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(OpenSpeechSettingsImplementation))]
namespace TextToSpeechDemo.Droid.Services
{
    public class OpenSpeechSettingsImplementation : IOpenSpeechSettingsPage
    {
        public void OpenSpeechSettingPage()
        {
            Intent intentOpenSpeechSettings = new Intent();
            intentOpenSpeechSettings.SetFlags(ActivityFlags.NewTask);

            intentOpenSpeechSettings.SetAction("com.android.settings.TTS_SETTINGS");
            Android.App.Application.Context.StartActivity(intentOpenSpeechSettings);
        }
    }
}