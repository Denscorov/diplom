using SQLite.Net;
using Windows.Storage;
using System.IO;

namespace Testing_OKM.DBCoonection
{
    static class DatabaseConncetion
    {
        static SQLiteConnection dbConnection;

        public static SQLiteConnection GetDbConnection()
        {
            SQLite.Net.Platform.WindowsPhone8.SQLitePlatformWP8 e = new SQLite.Net.Platform.WindowsPhone8.SQLitePlatformWP8();
            if (dbConnection == null)
            {
                dbConnection = new SQLiteConnection(e, App.DB_PATH);
                return dbConnection;
            }
            else
            {
                return dbConnection;
            }
        }
    }
}
