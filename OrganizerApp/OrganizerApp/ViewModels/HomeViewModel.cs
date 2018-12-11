using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using OrganizerApp.Models;
using OrganizerApp.Services;

namespace OrganizerApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        bool isWeatherLoaded = false;
        public bool IsWeatherLoaded
        {
            get { return isWeatherLoaded; }
            set { SetProperty(ref isWeatherLoaded, value); }
        }

        bool isTaskBusy = false;
        public bool IsTaskBusy
        {
            get { return isTaskBusy; }
            set { SetProperty(ref isTaskBusy, value); }
        }

        public ObservableCollection<Event> Items { get; set; }

        public ObservableCollection<ToDoTask> Tasks { get; set; }

        public Weather _weatherDetails { get; set; }
        public Weather WeatherDetails
        {
            set
            {
                if (_weatherDetails != value)
                {
                    _weatherDetails = value;
                    OnPropertyChanged("WeatherDetails");
                }
            }
            get
            {
                return _weatherDetails;
            }
        }
        
        public Command LoadItemsCommand { get; set; }

        public Command LoadWeatherCommand { get; set; }

        public Command LoadTasksCommand { get; set; }

        public HomeViewModel()
        {
            Title = "Event";
            Items = new ObservableCollection<Event>();
            Tasks = new ObservableCollection<ToDoTask>();
            WeatherDetails = new Weather();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoadWeatherCommand = new Command(async () => await ExecuteWeatherCommand());
            LoadTasksCommand = new Command(async () => await ExecuteLoadTasksCommand());
        }

        async Task ExecuteWeatherCommand()
        {
            if (IsWeatherLoaded)
                return;

            IsWeatherLoaded = false;

            try
            {
                WeatherDetails = await WeatherService.GetWeather("");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsWeatherLoaded = true;
            }           
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await EventDataStore.GetItemsAsync();
                 
                foreach (var item in items)
                {
                    if(item.RepeatTypeId == (int)RepeatTypeEnum.Monthly && item.EventDate.Day == DateTime.Now.Day)
                    {   //Monthly -> day
                        Items.Add(item);
                    }
                    else if (item.RepeatTypeId == (int)RepeatTypeEnum.Annual && item.EventDate.Day == DateTime.Now.Day && item.EventDate.Day == DateTime.Now.Day)
                    {   //Annual -> day & month
                        Items.Add(item);
                    }
                    else if (item.RepeatTypeId == (int)RepeatTypeEnum.NoRepeat && item.EventDate < DateTime.Now)
                    {   //no repeat then delete entries < eventdate
                        EventDataStore.DeleteItemAsync(item.Id);
                    }
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

        async Task ExecuteLoadTasksCommand()
        {
            if (IsTaskBusy)
                return;

            IsTaskBusy = true;

            try
            {
                Tasks.Clear();
                var tasks = await ToDoDataStore.GetItemsAsync();

                foreach (var task in tasks)
                {
                    Tasks.Add(task);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsTaskBusy = false;
            }
        }
    }
}