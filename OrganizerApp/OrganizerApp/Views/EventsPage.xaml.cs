using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using OrganizerApp.Models;
using OrganizerApp.Views;
using OrganizerApp.ViewModels;

namespace OrganizerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventsPage : ContentPage
    {
        EventsViewModel viewModel;

        public EventsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new EventsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Event;
            if (item == null)
                return;

            await Navigation.PushAsync(new EventDetailPage(new EventDetailViewModel(item)));

            // Manually deselect item.
            EventsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewEventPage()));
            //await Navigation.PushAsync(new NavigationPage(new NewEventPage()));--no
        }

        async void DeleteItem_Clicked(object sender, EventArgs e)
        {
            var itemId = ((TappedEventArgs)e).Parameter;
            var eventItem = new Event { Id = Convert.ToInt32(itemId) };
            MessagingCenter.Send(this, "DeleteEvent", eventItem);
            EventsListView.ItemsSource = viewModel.Items;
        }

        async void EditItem_Clicked(object sender, EventArgs e)
        {
            var itemId = ((TappedEventArgs)e).Parameter;
            var eventItem = new Event { Id = Convert.ToInt32(itemId),  };
            var value = viewModel.Items.Where(x => x.Id.Equals(itemId)).FirstOrDefault();
            
            await Navigation.PushModalAsync(new NavigationPage(new EditEventPage(value)));
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}