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

[assembly: Dependency(typeof(TextToSpeechImplementation))]

namespace TextToSpeechDemo.Droid.Services
{
    public class TextToSpeechImplementation : ITextToSpeech
    {
        private MySpeaker _speaker;

        public TextToSpeechImplementation()
        {
            _speaker = new MySpeaker();

        }
        public void Speak(string text)
        {
            _speaker.Speak(text);
        }
    }
}