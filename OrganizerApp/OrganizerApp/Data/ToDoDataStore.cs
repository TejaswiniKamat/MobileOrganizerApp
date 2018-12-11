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
    public class ToDoDataStore : BaseDataStore, IDataStore<ToDoTask>
    {
        static object locker = new object();

        public ToDoDataStore()
        {
            database.CreateTable<ToDoTask>();
        }

        public async Task<bool> SaveItemAsync(ToDoTask item)
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
            //return await Task.FromResult(true);
        }
        public async Task<ToDoTask> GetItemAsync(int id)
        {
            var item = database.Table<ToDoTask>().FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(item);
        }

        public async Task<IEnumerable<ToDoTask>> GetItemsAsync()
        {
            var items = (from i in database.Table<ToDoTask>() select i).ToList();
            return await Task.FromResult(items);
        }
    }
}
