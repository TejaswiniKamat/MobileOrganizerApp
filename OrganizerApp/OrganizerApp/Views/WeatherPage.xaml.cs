using OrganizerApp.Models;
using OrganizerApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrganizerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
            BindingContext = new Weather();
        }

        protected override async void OnAppearing()
        {
            var weather = await WeatherService.GetWeather("");
            BindingContext = weather;
        }

        private async void GetWeatherBtn_Clicked(object sender, EventArgs e)
        {
            //if (!String.IsNullOrEmpty(zipCodeEntry.Text))
            {
                Weather weather = await WeatherService.GetWeather("");//zipCodeEntry.Text
                BindingContext = weather;// weather;
            //    getWeatherBtn.Text = "Search Again";
            }
        }
    }
}