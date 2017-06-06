using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Testing_3
{
    static class DBConnection
    {
        public static string DB_NAME = "test.db";
        public static string DB_PATH = Path.Combine(ApplicationData.Current.LocalFolder.Path, DB_NAME);

        static SQLiteConnection dbCoonection;

        public static SQLiteConnection GetCoonection()
        {
            if (dbCoonection != null)
            {
                return dbCoonection;
            }
            else
            {
                SQLite.Net.Platform.WindowsPhone8.SQLitePlatformWP8 e = new SQLite.Net.Platform.WindowsPhone8.SQLitePlatformWP8();
                dbCoonection = new SQLiteConnection(e, DB_PATH);
                return dbCoonection;
            }
        }

    }
}
