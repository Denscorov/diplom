using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing_3.Model;
using SQLiteNetExtensions.Extensions;

namespace Testing_3.VIewModel
{
    class TestViewModel : BaseViewModel<Test>
    {
        bool dateSorted = true;
        bool typeSorted = true;

        public TestViewModel()
        {
            database = DBConnection.GetCoonection();
            Entities = new ObservableCollection<Test>();
        }

        public void AddTest(Test test)
        {
            database.Insert(test);
        }

        public void GetAllTests()
        {
            Entities = new ObservableCollection<Test>(database.Table<Test>());
        }

        public void SortBytype()
        {
            if (typeSorted)
            {
                Entities = new ObservableCollection<Test>(Entities.OrderBy(e => e.Type));
                typeSorted = false;
            }
            else
            {
                Entities = new ObservableCollection<Test>(Entities.OrderByDescending(e => e.Type));
                typeSorted = true;
            }
            
        }

        public void SortByDate()
        {
            if (dateSorted)
            {
                Entities = new ObservableCollection<Test>(Entities.OrderBy(e => DateTime.Parse(e.Date)));
                dateSorted = false;
            }
            else
            {
                Entities = new ObservableCollection<Test>(Entities.OrderByDescending(e => DateTime.Parse(e.Date)));
                dateSorted = true;
            }
        }

    }
}
