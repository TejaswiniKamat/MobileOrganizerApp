using OrganizerApp.Models;
using OrganizerApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrganizerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoTaskDetailPage : ContentPage
    {
        ToDoTaskDetailViewModel viewModel;

        public ToDoTaskDetailPage(ToDoTaskDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ToDoTaskDetailPage()
        {
            InitializeComponent();

            var item = new ToDoTask
            {
                Description = "This is an task description."
            };

            viewModel = new ToDoTaskDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}