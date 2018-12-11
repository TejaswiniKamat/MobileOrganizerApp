using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using OrganizerApp;
using OrganizerApp.Views;

namespace OrganizerApp
{
    public class App : Application
    {
        //RootPage masterPage = new RootPage();
        public App()
        {
            //// The root page of your application
            //MainPage = new ContentPage
            //{
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new Label {
            //                HorizontalTextAlignment = TextAlignment.Center,
            //                Text = "Welcome to Xamarin Forms!"
            //            }
            //        }
            //    }
            //};
            

            //
            //MainPage = new MapPage { Title = "Map/Zoom", Icon = "glyphish_74_location.png" };
            var tabs = new TabbedPage();

            // demonstrates the map control with zooming and map-types
            tabs.Children.Add(new MapPage { Title = "Map/Zoom", Icon = "glyphish_74_location.png" });

            // demonstrates the map control with zooming and map-types
            tabs.Children.Add(new PinPage { Title = "Pins", Icon = "glyphish_07_map_marker.png" });

            // demonstrates the Geocoder class
            tabs.Children.Add(new GeocoderPage { Title = "Geocode", Icon = "glyphish_13_target.png" });

            // opens the platform's native Map app
            //tabs.Children.Add(new MapAppPage { Title = "Map App", Icon = "glyphish_103_map.png" });

            //MainPage = tabs;
            //MainPage = new MainPage1();



            //var detailPage = new NavigationPage(new HomePage());
            //MainPage = new MasterPage();

            //var masterPage = MainPage as MasterDetailPage;
            //masterPage.Detail = detailPage;
            MainPage = new RootPage();


        }

        

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
