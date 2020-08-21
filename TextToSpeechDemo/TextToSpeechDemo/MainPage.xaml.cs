using System;
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
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

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
            var locale = locales.FirstOrDefault(s=>s.Language==(string) LanguagesPicker.SelectedItem);
           
            var settings = new SpeechOptions()
            {
                Volume = .75f,
                Pitch = 1.0f,
                Locale = locale
            };
            if (string.IsNullOrWhiteSpace(TextEntry.Text))
            {
                await DisplayAlert("Error Empty", "please type something to speech!", "cancel");
                return;
            }
            await TextToSpeech.SpeakAsync(TextEntry.Text, settings);
        }
    }
}
