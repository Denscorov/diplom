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
        //SQLiteConnection database;
        //ObservableCollection<Course> courses;
        //public ObservableCollection<Course> Courses
        //{
        //    get
        //    {
        //        return courses;
        //    }
        //    set
        //    {
        //        if (value != courses)
        //        {
        //            courses = value;
        //        }
        //    }
        //}

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
