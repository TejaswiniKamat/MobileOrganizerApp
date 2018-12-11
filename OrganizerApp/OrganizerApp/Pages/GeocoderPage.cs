using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace OrganizerApp
{
    public class GeocoderPage : ContentPage
    {
        Geocoder geoCoder;
        Label l = new Label();

        public GeocoderPage()
        {
            geoCoder = new Geocoder();

            var b1 = new Button { Text = "Reverse geocode '18.562622, 73.808723'" };
            b1.Clicked += async (sender, e) => {
                var fortMasonPosition = new Position(18.562622, 73.808723);
                var possibleAddresses = await geoCoder.GetAddressesForPositionAsync(fortMasonPosition);
                foreach (var a in possibleAddresses)
                {
                    l.Text += a + "\n";
                }
            };

            var b2 = new Button { Text = "Geocode 'Aundh, Pune, Maharashtra'" };
            b2.Clicked += async (sender, e) => {
                var xamarinAddress = "Aundh, Pune, Maharashtra";
                var approximateLocation = await geoCoder.GetPositionsForAddressAsync(xamarinAddress);
                foreach (var p in approximateLocation)
                {
                    l.Text += p.Latitude + ", " + p.Longitude + "\n";
                }
            };

            Content = new StackLayout
            {
                Padding = new Thickness(0, 20, 0, 0),
                Children = {
                    b2,
                    b1,
                    l
                }
            };
        }
    }
}
