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


    }
}
