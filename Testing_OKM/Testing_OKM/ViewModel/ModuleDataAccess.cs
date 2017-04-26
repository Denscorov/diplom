using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Testing_OKM.DBCoonection;
using Testing_OKM.Model;

namespace Testing_OKM.ViewModel
{
    /// <summary>
    /// Надає доступ до записів таблиці Module
    /// </summary>
    class ModuleDataAccess
    {
        SQLiteConnection database;
        static object collisionLock = new object();

        public ObservableCollection<Module> Modules { get; set; }

        public ModuleDataAccess()
        {
            database = DatabaseConncetion.GetDbConnection();
            Modules = new ObservableCollection<Module>();
        }

        /// <summary>
        /// Повертає всі записи
        /// </summary>
        /// <returns></returns>
        public void GetModules()
        {
            lock (collisionLock)
            {
                
                Modules = new ObservableCollection<Module>(database.GetAllWithChildren<Module>());
            }
        }
        /// <summary>
        /// Повертає вибрані по Id курсу
        /// </summary>
        /// <returns></returns>
        public void GetModules(int CourseId)
        {
            lock (collisionLock)
            {
                AddedThemeToModule();
                Modules = new ObservableCollection<Module>(database.GetAllWithChildren<Module>(m => m.CourseId == CourseId));
            }
        }


        #region add test records
        public void AddedThemeToModule()
        {
            lock (collisionLock)
            {
                foreach (var item in Modules)
                {
                    Random r = new Random();
                    for (int i = 0; i < r.Next(1, 5); i++)
                    {
                        var t = new Theme("Тема бла бла бла в модулі: " + item.Id);
                        database.Insert(t);
                        item.Themes.Add(t);
                    }
                    database.UpdateWithChildren(item);
                }
            }
        }

        #endregion

    }
}
