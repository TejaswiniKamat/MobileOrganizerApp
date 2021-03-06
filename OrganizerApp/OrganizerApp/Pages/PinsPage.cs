﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace OrganizerApp
{
    public class PinPage : ContentPage
    {
        Map map;

        public PinPage()
        {
            map = new Map
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            map.MoveToRegion(MapSpan.FromCenterAndRadius(
               new Position(18.562622, 73.808723), Distance.FromMiles(3))); 

            var position = new Position(18.562622, 73.808723); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "Aundh",
                Address = "custom detail info"
            };
            map.Pins.Add(pin);


            // create buttons
            var morePins = new Button { Text = "Add more pins" };
            morePins.Clicked += (sender, e) => {
                map.Pins.Add(new Pin
                {
                    Position = new Position(18.562422, 73.808723),
                    Label = "Boardwalk"
                });
                map.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Position(18.562622, 73.808723), Distance.FromMiles(1.5)));

            };
            var reLocate = new Button { Text = "Re-center" };
            reLocate.Clicked += (sender, e) => {
                map.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Position(18.562622, 73.808723), Distance.FromMiles(3)));
            };
            var buttons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {
                    morePins, reLocate
                }
            };

            // put the page together
            Content = new StackLayout
            {
                Spacing = 0,
                Children = {
                    map,
                    buttons
                }
            };
        }
    }
}
