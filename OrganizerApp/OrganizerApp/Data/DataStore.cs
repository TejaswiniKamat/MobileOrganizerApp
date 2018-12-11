using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OrganizerApp.Data
{
    public class BaseDataStore
    {
        public SQLiteConnection database;

        public BaseDataStore()
        {
            database = DependencyService.Get<IFileHelper>().GetConnection("OrganizerAppSQLite.db3");

        }
    }
}
