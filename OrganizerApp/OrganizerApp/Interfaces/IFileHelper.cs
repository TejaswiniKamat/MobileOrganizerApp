using SQLite;

namespace OrganizerApp
{
    public interface IFileHelper
    {
        SQLiteConnection GetConnection(string filename);
    }
}
