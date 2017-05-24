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
    class StudentViewModel : BaseViewModel<Student>
    {
        public StudentViewModel()
        {
            database = DBConnection.GetCoonection();
            Entities = new ObservableCollection<Student>();
        }

        public Student getActive()
        {
            return database.Table<Student>().Where(s => s.Is_Active).SingleOrDefault();
        }

        public void addStudent(Student student)
        {
            database.Insert(student);
        }

    }
}
