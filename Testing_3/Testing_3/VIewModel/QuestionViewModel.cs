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
    class QuestionViewModel :BaseViewModel<Question>
    {
        public QuestionViewModel()
        {
            database = DBConnection.GetCoonection();
            Entities = new ObservableCollection<Question>();
        }

        public void GetQuestionByCourseId(int id)
        {
            var courses = database.GetAllWithChildren<Course>(c => c.Id == id, true).SingleOrDefault(); ;
            var questions = from module in courses.Modules
                            where module.CourseId == courses.Id
                            select module;
        }

    }
}
