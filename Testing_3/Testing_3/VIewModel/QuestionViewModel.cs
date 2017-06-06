using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Testing_3.Model;
using SQLiteNetExtensions.Extensions;
using System;

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
                    if (App.Level != -1)
                    {
                        q.AddRange(theme.Questions.Where(qq => qq.Level == App.Level));
                    }
                    else
                    {
                        q.AddRange(theme.Questions);
                    }
                    
                }
            }
            Shuffle(q);
            Entities = new ObservableCollection<Question>(q);
        }

        public void GetQuestionsByModulesId(int[] ids)
        {
            var themes = database.GetAllWithChildren<Theme>(t => ids.Contains(t.ModuleId), true);
            List<Question> q = new List<Question>();
            foreach (var theme in themes)
            {
                if (App.Level != -1)
                {
                    q.AddRange(theme.Questions.Where(qq => qq.Level == App.Level));
                }
                else
                {
                    q.AddRange(theme.Questions);
                }
            }
            Shuffle(q);
            Entities = new ObservableCollection<Question>(q);
        }

        public void GetQuestionsByThemesId(int[] ids)
        {
            List<Question> questions;
            if (App.Level != -1)
            {
                questions = database.GetAllWithChildren<Question>(q => ids.Contains(q.ThemeId) && q.Level == App.Level, true);
            }
            else
            {
                questions = database.GetAllWithChildren<Question>(q => ids.Contains(q.ThemeId), true);
            }

            Shuffle(questions);
            Entities = new ObservableCollection<Question>(questions);
        }

        public string GetNames(string type, int[] ids)
        {
            switch (type)
            {
                case "Course":
                    return String.Join(", ", database.Table<Course>().Where(c => ids.Contains(c.Id)).Select(c => c.Name).ToArray());
                case "Module":
                    return String.Join(", ", database.Table<Module>().Where(m => ids.Contains(m.Id)).Select(m => m.Name).ToArray());
                case "Theme":
                    return String.Join(", ", database.Table<Theme>().Where(t => ids.Contains(t.Id)).Select(t => t.Name).ToArray());
                default:
                    return "";
            }
        }

        public void removeAll()
        {
            database.DeleteAll<Question>();
        }

        public void InsertList(List<Question> questions)
        {
            database.InsertAllWithChildren(questions);
        }
    }
}
