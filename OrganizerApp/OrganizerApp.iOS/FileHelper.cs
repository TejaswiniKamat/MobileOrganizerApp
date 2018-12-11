using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OrganizerApp.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace OrganizerApp.iOS
{
    public class FileHelper : IFileHelper
    {
        public SQLiteConnection GetConnection(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            var path = Path.Combine(libFolder, filename);

            var conn = new SQLiteConnection(path);

            // Return the database connection 
            return conn;
        }
    }
}