using SQLite.Net;
using Testing_OKM.Model;
using System.Collections.ObjectModel;
using Testing_OKM.DBCoonection;
using System.Linq;
using SQLiteNetExtensions.Extensions;
using System.Diagnostics;
using System.Collections.Generic;

namespace Testing_OKM.ViewModel
{
    /// <summary>
    /// Надає доступ до записів таблиці Course
    /// </summary>
    class CourseDataAccess
    {
        SQLiteConnection database;
        static object collisionLock = new object();

        public ObservableCollection<Course> Courses { get; set; }

        public CourseDataAccess()
        {
            database = DatabaseConncetion.GetDbConnection();

            if (Debugger.IsAttached && !database.Table<Course>().Any())
            {
                setTestData();
            }
        }

        public void GetCourses()
        {
            Courses = new ObservableCollection<Course>(database.GetAllWithChildren<Course>());
        }

        void setTestData()
        {
            for (int i = 0; i < 5; i++)
            {
                var c = new Course("Курс " + i.ToString());
                database.Insert(c);
                for (int j = 0; j < i; j++)
                {
                    var m = new Module("Модуль " + j + "в курсі " + c.Id);
                    database.Insert(m);
                    c.Modules.Add(m);
                }
                database.UpdateWithChildren(c);
            }
        }
    }
}
