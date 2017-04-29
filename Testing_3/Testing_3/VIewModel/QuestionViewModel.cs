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
    class QuestionViewModel : BaseViewModel<Question>
    {
        public QuestionViewModel()
        {
            database = DBConnection.GetCoonection();
            Entities = new ObservableCollection<Question>();
        }

       

        //public void GetQuestionsByCourseId(int id)
        //{
        //    var modules = database.GetAllWithChildren<Module>(m => m.CourseId == id, true);
        //    List<Question> q = new List<Question>();
        //    foreach (var module in modules)
        //    {
        //        foreach (var theme in module.Themes)
        //        {
        //            q.AddRange(theme.Questions);
        //        }
        //    }
        //    Shuffle(q);
        //    Entities = new ObservableCollection<Question>(q);
        //}

        public void GetQuestionsByCoursesId(int[] ids)
        {
            var modules = database.GetAllWithChildren<Module>(m => ids.Contains(m.CourseId), true);
            List<Question> q = new List<Question>();
            foreach (var module in modules)
            {
                foreach (var theme in module.Themes)
                {
                    q.AddRange(theme.Questions);
                }
            }
            Shuffle(q);
            Entities = new ObservableCollection<Question>(q);
        }

        //public void GetQuestionsByModuleId(int id)
        //{
        //    var themes = database.GetAllWithChildren<Theme>(t => t.ModuleId == id);
        //    List<Question> q = new List<Question>();
        //    foreach (var theme in themes)
        //    {
        //        q.AddRange(theme.Questions);
        //    }
        //    Shuffle(q);
        //    Entities = new ObservableCollection<Question>(q);
        //}

        public void GetQuestionsByModulesId(int[] ids)
        {
            var themes = database.GetAllWithChildren<Theme>(t => ids.Contains(t.ModuleId));
            List<Question> q = new List<Question>();
            foreach (var theme in themes)
            {
                q.AddRange(theme.Questions);
            }
            Shuffle(q);
            Entities = new ObservableCollection<Question>(q);
        }

        //public void GetQuestionsByThemeId(int id)
        //{
        //    var themes = database.GetAllWithChildren<Theme>(t => t.Id == id);
        //    List<Question> q = new List<Question>();
        //    foreach (var theme in themes)
        //    {
        //        q.AddRange(theme.Questions);
        //    }
        //    Shuffle(q);
        //    Entities = new ObservableCollection<Question>(q);
        //}

        public void GetQuestionsByThemesId(int[] ids)
        {
            var themes = database.GetAllWithChildren<Theme>(t => ids.Contains(t.Id));
            List<Question> q = new List<Question>();
            foreach (var theme in themes)
            {
                q.AddRange(theme.Questions);
            }
            Shuffle(q);
            Entities = new ObservableCollection<Question>(q);
        }
    }
}
