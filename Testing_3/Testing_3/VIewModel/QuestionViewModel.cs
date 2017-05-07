using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            Entities = new ObservableCollection<Question>(q);
        }

        public void GetQuestionsByModulesId(int[] ids)
        {
            var themes = database.GetAllWithChildren<Theme>(t => ids.Contains(t.ModuleId), true);
            List<Question> q = new List<Question>();
            foreach (var theme in themes)
            {
                q.AddRange(theme.Questions);
            }
            Entities = new ObservableCollection<Question>(q);
        }

        public void GetQuestionsByThemesId(int[] ids)
        {
            var questions = database.GetAllWithChildren<Question>(q => ids.Contains(q.ThemeId), true);
            Entities = new ObservableCollection<Question>(questions);
        }
    }
}
