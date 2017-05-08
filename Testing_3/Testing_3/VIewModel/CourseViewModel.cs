using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using System.Collections.ObjectModel;
using Testing_3.Model;
using SQLiteNetExtensions.Extensions;

namespace Testing_3.VIewModel
{
    class CourseViewModel : BaseViewModel<Course>
    {
        public CourseViewModel()
        {
            database = DBConnection.GetCoonection();
            Entities = new ObservableCollection<Course>();
        }

        public void GetAllCourses()
        {
            Entities = new ObservableCollection<Course>(database.GetAllWithChildren<Course>());
        }
    }
}
