﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace TextToSpeechDemo
{
    public partial class MainPage : ContentPage
    {
        private ITextToSpeech Myspeaker;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            Myspeaker = DependencyService.Get<ITextToSpeech>();

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            LanguagesPicker.ItemsSource =await GetLanguagesListAsync();
        }
        public Command SpeakNowCommand
        {
            get
            {
                return new Command(async () => await SpeakNow());
            }
        }
        public Command SpeechSettingsCommand
        {
            get
            {
                return new Command( () =>DependencyService.Get<IOpenSpeechSettingsPage>().OpenSpeechSettingPage());
            }
        }
        public async Task<List<string>> GetLanguagesListAsync()
        {
            
                return (await TextToSpeech.GetLocalesAsync()).Select(s => s.Language).ToList();
          
        }
        public async Task SpeakNow()
        {
            var locales = await TextToSpeech.GetLocalesAsync();
            if (LanguagesPicker.SelectedItem==null)
            {
                await DisplayAlert("Error null", "please type select a Language", "cancel");
                return;
            }
            if (string.IsNullOrWhiteSpace(TextEntry.Text))
            {
                await DisplayAlert("Error Empty", "please type something to speech!", "cancel");
                return;
            }
            if (Device.RuntimePlatform== Device.Android)
            {
                Myspeaker.Speak(TextEntry.Text);
            }
            else
            {
                var locale = locales.FirstOrDefault(s => s.Language == (string)LanguagesPicker.SelectedItem);
                var settings = new SpeechOptions()
                {
                    Volume = .75f,
                    Pitch = 1.0f,
                    Locale = locale
                };

                await TextToSpeech.SpeakAsync(TextEntry.Text, settings);

            }

        }
    }
}
