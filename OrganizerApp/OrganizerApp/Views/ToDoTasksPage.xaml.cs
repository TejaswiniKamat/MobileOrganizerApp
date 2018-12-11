using OrganizerApp.Models;
using OrganizerApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrganizerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoTasksPage : ContentPage
    {
        ToDoTaskViewModel viewModel;

        public ToDoTasksPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ToDoTaskViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ToDoTask;
            if (item == null)
                return;

            await Navigation.PushAsync(new ToDoTaskDetailPage(new ToDoTaskDetailViewModel(item)));

            // Manually deselect item.
            TaskListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewToDoTaskPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Tasks.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}