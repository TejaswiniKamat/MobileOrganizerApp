using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using OrganizerApp.Models;
using OrganizerApp.Views;

namespace OrganizerApp.ViewModels
{
    public class ToDoTaskViewModel : BaseViewModel
    {
        public ObservableCollection<ToDoTask> Tasks { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ToDoTaskViewModel()
        {
            Title = "Browse";
            Tasks = new ObservableCollection<ToDoTask>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewToDoTaskPage, ToDoTask>(this, "AddTask", async (obj, task) =>
            {
                var _task = task as ToDoTask;
                Tasks.Add(_task);
                await ToDoDataStore.SaveItemAsync(_task);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Tasks.Clear();
                var items = await ToDoDataStore.GetItemsAsync();
                foreach (var item in items)
                {
                    Tasks.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}