using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Testing_OKM.ViewModel;
using Testing_OKM.Model;

namespace Testing_OKM.View
{
    public partial class TestingPage : PhoneApplicationPage
    {
        string TypeTest = "";
        string ObjectId = "";
        int index = 0;

        QuestionDataAccess dataAccess;

        public TestingPage()
        {
            InitializeComponent();
            dataAccess = new QuestionDataAccess();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            NavigationContext.QueryString.TryGetValue("TypeTest", out TypeTest);
            NavigationContext.QueryString.TryGetValue("ObjectId", out ObjectId);

            MessageBox.Show("Type = " + TypeTest + ", Id = " + ObjectId);

            GetQuestions(TypeTest, Convert.ToInt32(ObjectId));

            this.DataContext = dataAccess;

            SetQuestion();

        }

        public void GetQuestions(string type, int id)
        {
            switch (type)
            {
                case "Testing_OKM.Model.Course":
                    dataAccess.GetQuestionsByCourseId(id);
                    break;
                case "Testing_OKM.Model.Module":
                    dataAccess.GetQuestionByModuleId(id);
                    break;
                case "Testing_OKM.Model.Theme":
                    dataAccess.GetQuestionByThemeId(id);
                    break;
                default:
                    break;
            }
        }

        public void SetQuestion()
        {
            var question = dataAccess.Questions[index];
            QuestionText.Text = question.QuestionText;
            switch (question.Type)
            {
                case 0:
                    ListAnswer.ItemTemplate = (DataTemplate)this.Resources["AnswerType0"];
                    break;
                case 1:
                    ListAnswer.ItemTemplate = (DataTemplate)this.Resources["AnswerType1"];
                    break;
                case 2:
                    ListAnswer.ItemTemplate = (DataTemplate)this.Resources["AnswerType2"];
                    break;
                default:
                    break;
            }
            ListAnswer.ItemsSource = question.Answers;
            index++;
            
        }

        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            SetQuestion();
        }
    }
}