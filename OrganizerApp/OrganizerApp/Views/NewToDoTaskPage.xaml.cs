using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using OrganizerApp.Models;

namespace OrganizerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewToDoTaskPage : ContentPage
    {
        public ToDoTask Task { get; set; }

        public NewToDoTaskPage()
        {
            InitializeComponent();

            Task = new ToDoTask
            {
                Description = "This is an task description."
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddTask", Task);
            await Navigation.PopModalAsync();
        }
    }
}