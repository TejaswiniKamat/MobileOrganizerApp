using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrganizerApp.Interfaces
{
    public interface IDataStore<T>
    {
        Task<bool> SaveItemAsync(T item);
        void DeleteItemAsync(int id);
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync();
    }
}

