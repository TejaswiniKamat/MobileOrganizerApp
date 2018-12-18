using OrganizerApp.Data;
using OrganizerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizerApp.Services
{
    public class WeatherService
    {
        public static async Task<Weather> GetWeather(string zipCode)
        {
            //Sign up for a free API key at http://openweathermap.org/appid  
            string key = "d1646e69e6d56ab408a02edaa3d73b2a";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?"
                //+ "zip=" + zipCode + ", us&appid=" + key + "&units=imperial";
                + "q=Pune,india" + "&appid=" + key + "&units=imperial";

            dynamic results = await ExternalDataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Title = (string)results["name"];
                var temperatureInF = results["main"]["temp"];
                var temperatureInC = (temperatureInF - 32) / 1.8;
                weather.Temperature = temperatureInC.ToString("0.00") + " C";
                weather.Wind = (string)results["wind"]["speed"] + " mph";
                weather.Humidity = (string)results["main"]["humidity"] + " %";
                weather.Visibility = (string)results["weather"][0]["main"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                weather.Sunrise = sunrise.ToString() + " UTC";
                weather.Sunset = sunset.ToString() + " UTC";
                return weather;
            }
            else
            {
                return null;
            }
        }
    }
}
