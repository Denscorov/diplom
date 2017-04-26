using SQLite.Net;

namespace Test_1
{
    static class DBConnection
    {
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
                dbCoonection = new SQLiteConnection(e,App.DB_PATH);
                return dbCoonection;
            }
        }
       
    }
}
