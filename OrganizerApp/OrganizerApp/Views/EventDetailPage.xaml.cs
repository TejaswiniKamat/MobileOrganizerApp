using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using OrganizerApp.Models;
using OrganizerApp.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace OrganizerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventDetailPage : ContentPage
    {
        EventDetailViewModel viewModel;

        public EventDetailPage(EventDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public EventDetailPage()
        {
            InitializeComponent();

            var item = new Event
            {
                Name = "Event 1",
                Description = "This is an event description."
            };

            viewModel = new EventDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}