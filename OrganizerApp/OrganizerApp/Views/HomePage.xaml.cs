using OrganizerApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrganizerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        HomeViewModel viewModel;

        public HomePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new HomeViewModel();
        }
        
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            
            viewModel.LoadWeatherCommand.Execute(null);
                               
            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
            if (viewModel.Tasks.Count == 0)
                viewModel.LoadTasksCommand.Execute(null);
        }
    }
}