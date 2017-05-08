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
    class ModuleViewModel : BaseViewModel<Module>
    {
        public ModuleViewModel()
        {
            database = DBConnection.GetCoonection();
            Entities = new ObservableCollection<Module>();
        }

        public void GetAllModules()
        {
            Entities = new ObservableCollection<Module>(database.GetAllWithChildren<Module>());
        }

        public void GetModulesByCourseId(int id)
        {
            Entities = new ObservableCollection<Module>(database.GetAllWithChildren<Module>(m => m.CourseId == id));
        }

        public void GetModulesByCoursesId(int[] ids)
        {
            Entities = new ObservableCollection<Module>(database.GetAllWithChildren<Module>(m => ids.Contains(m.CourseId)));
        }
    }
}
