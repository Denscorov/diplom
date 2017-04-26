using SQLite.Net;
using System.Collections.ObjectModel;
using Testing_OKM.DBCoonection;
using Testing_OKM.Model;
using SQLiteNetExtensions.Extensions;
using System.Collections.Generic;
using System;

namespace Testing_OKM.ViewModel
{
    class QuestionDataAccess
    {
        SQLiteConnection database;
        static object collisionLock = new object();

        public ObservableCollection<Question> Questions { get; set; }

        public QuestionDataAccess()
        {
            database = DatabaseConncetion.GetDbConnection();
        }
        /// <summary>
        /// Повертає набір питань які входять у тему визначену по Id
        /// </summary>
        /// <param name="themeId"></param>
        public void GetQuestionByThemeId(int themeId)
        {
            Questions = new ObservableCollection<Question>(database.GetAllWithChildren<Question>(q => q.ThemeId == themeId));
        }
        /// <summary>
        /// Повертає набір питань які входять у Модуль визначений по Id
        /// </summary>
        /// <param name="moduleId"></param>
        public void GetQuestionByModuleId(int moduleId)
        {
            var module = database.GetAllWithChildren<Module>(m => m.Id == moduleId, true)[0];
            var q = new List<Question>();
            foreach (var theme in module.Themes)
            {
                q.AddRange(theme.Questions);    
            }
            Questions = new ObservableCollection<Question>(q);
        }
        /// <summary>
        /// Повертає набір питань які входять у курс визначений по Id
        /// </summary>
        /// <param name="courseId"></param>
        public void GetQuestionsByCourseId(int courseId)
        {
            var course = database.GetAllWithChildren<Course>(c => c.Id == courseId, true)[0];
            var q = new List<Question>();
            foreach (var module in course.Modules)
            {
                foreach (var theme in module.Themes)
                {
                    q.AddRange(theme.Questions);
                }
            }
            Questions = new ObservableCollection<Question>(q);
        }

        public void AddTestQuestionsToTheme(Theme theme)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var q = new Question("question bla bla bla....", i, j);
                    database.Insert(q);
                    theme.Questions.Add(q);
                }
            }
            database.UpdateWithChildren(theme);
        }

        public void AddedAnswerToQuestion(Theme theme)
        {
            foreach (var question in theme.Questions)
            {
                switch (question.Type)
                {
                    case 0:
                        Answer answer;
                        for (int i = 0; i < 2; i++)
                        {
                            if (i == 1)
                            {
                                answer = new Answer("answer to question :" + question.Id, true);
                            }
                            else
                            {
                                answer = new Answer("answer to question :" + question.Id, false);
                            }
                            database.Insert(answer);
                            question.Answers.Add(answer);
                        }
                        database.UpdateWithChildren(question);
                        break;
                    case 1:
                        Random r = new Random();
                        Answer answer1;
                        for (int i = 0; i < 3; i++)
                        {
                            answer1 = new Answer("answer to question :" + question.Id, Convert.ToBoolean(r.Next(0, 1)));
                            database.Insert(answer1);
                            question.Answers.Add(answer1);
                        }
                        database.UpdateWithChildren(question);
                        break;
                    case 2:
                        Answer answer2 = new Answer("text answer to question id: " + question.Id, true);
                        database.Insert(answer2);
                        question.Answers.Add(answer2);
                        database.UpdateWithChildren(question);
                        break;
                }
            }
        }
    }
}
