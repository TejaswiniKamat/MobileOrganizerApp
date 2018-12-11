using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OrganizerApp.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace OrganizerApp.Droid
{
    public class FileHelper : IFileHelper
    {
        public SQLiteConnection GetConnection(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, filename);

            var conn = new SQLiteConnection(path);

            // Return the database connection 
            return conn;
        }
    }
}