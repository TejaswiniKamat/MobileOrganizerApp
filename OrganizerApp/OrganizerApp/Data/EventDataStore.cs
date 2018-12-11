using System;
using System.Collections.Generic;
using System.Text;
using OrganizerApp.Interfaces;
using OrganizerApp.Models;
using System.Threading.Tasks;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace OrganizerApp.Data
{
    public class EventDataStore : BaseDataStore, IDataStore<Event>
    {
        static object locker = new object();

        public EventDataStore()
        {
            database.CreateTable<Event>();
        }

        public async Task<bool> SaveItemAsync(Event item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
            }
            else
            {
                database.Insert(item);
            }
            return await Task.FromResult(true);
        }
        
        public void DeleteItemAsync(int id)
        {
            database.Delete<Event>(id);
        }
        public async Task<Event> GetItemAsync(int id)
        {
            var item = database.Table<Event>().FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(item);
        }

        public async Task<IEnumerable<Event>> GetItemsAsync()
        {
            var items = (from i in database.Table<Event>() select i).ToList();
            return await Task.FromResult(items);
        }
    }
}
