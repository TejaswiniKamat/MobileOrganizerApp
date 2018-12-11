using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using OrganizerApp.Models;
using OrganizerApp.Views;
using System.Linq;

namespace OrganizerApp.ViewModels
{
    public class EventsViewModel : BaseViewModel
    {
        public ObservableCollection<Event> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public EventsViewModel()
        {
            Title = "Event";
            Items = new ObservableCollection<Event>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewEventPage, Event>(this, "AddEvent", async (obj, item) =>
            {
                var _item = item as Event;
                Items.Add(_item);
                await EventDataStore.SaveItemAsync(_item);
            });

            MessagingCenter.Subscribe<EventsPage, Event>(this, "DeleteEvent", async (obj, item) =>
            {
                try
                {
                    var _item = item as Event;
                    var itemObj = Items.AsEnumerable().ToList().Where(x => x.Id == _item.Id).FirstOrDefault();
                    Items.Remove(itemObj);
                    EventDataStore.DeleteItemAsync(_item.Id);
                }
                catch (Exception ex)
                {

                }
            });

            MessagingCenter.Subscribe<EditEventPage, Event>(this, "EditEvent", async (obj, item) =>
            {
                try
                {
                    var _item = item as Event;
                    var itemObj = Items.Where(x => x.Id.Equals(item.Id)).FirstOrDefault();
                    itemObj.Name = _item.Name;
                    itemObj.Description = _item.Description;
                    itemObj.IsRepeat = _item.IsRepeat;
                    itemObj.UpdatedDate = _item.UpdatedDate;
                   
                    await EventDataStore.SaveItemAsync(_item);
                }
                catch (Exception ex)
                {

                }
            });
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
                    Items.Add(item);
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