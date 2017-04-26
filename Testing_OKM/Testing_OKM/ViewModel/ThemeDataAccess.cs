using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing_OKM.DBCoonection;
using Testing_OKM.Model;

namespace Testing_OKM.ViewModel
{
    class ThemeDataAccess
    {
        SQLiteConnection database;
        static object collisionLock = new object();

        public ObservableCollection<Theme> Themes { get; set; }

        public ThemeDataAccess()
        {
                database = DatabaseConncetion.GetDbConnection();
        }

        /// <summary>
        /// Повертає всі записи
        /// </summary>
        /// <returns></returns>
        public void GetThemes()
        {
            lock (collisionLock)
            {
                Themes = new ObservableCollection<Theme>(database.GetAllWithChildren<Theme>());
            }
        }
        /// <summary>
        /// Повертає вибрані по Id курсу
        /// </summary>
        /// <returns></returns>
        public void GetThemes(int ModuleId)
        {
            lock (collisionLock)
            {
                Themes = new ObservableCollection<Theme>(database.GetAllWithChildren<Theme>(t => t.ModuleId == ModuleId));
            }
        }
    }
}
