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
    class ThemeViewModel : BaseViewModel<Theme>
    {
        public ThemeViewModel()
        {
            database = DBConnection.GetCoonection();
            Entities = new ObservableCollection<Theme>();
        }

        public void GetAllThemes()
        {
            Entities = new ObservableCollection<Theme>(database.GetAllWithChildren<Theme>());
        }

        public void GetThemesByModuleId(int id)
        {
            Entities = new ObservableCollection<Theme>(database.GetAllWithChildren<Theme>(t => t.ModuleId == id));
        }

        public void GetThemesByModulesId(int[] ids)
        {
            Entities = new ObservableCollection<Theme>(database.GetAllWithChildren<Theme>(m => ids.Contains(m.ModuleId)));
        }
    }
}
