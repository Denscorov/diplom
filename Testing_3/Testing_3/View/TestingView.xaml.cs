using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Testing_3.VIewModel;
using Testing_3.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Testing_3.CompareString;

namespace Testing_3.View
{
    public partial class TestingView : PhoneApplicationPage
    {
        QuestionViewModel questionVM;

        string type = "";
        string str = "";

        QuestionNotify qNotify;

        public TestingView()
        {
            InitializeComponent();
            questionVM = new QuestionViewModel();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            NavigationContext.QueryString.TryGetValue("type", out type);
            NavigationContext.QueryString.TryGetValue("str", out str);

            switch (type)
            {
                case "Course":
                    questionVM.GetQuestionsByCoursesId(str.Split(' ').Select(int.Parse).ToArray());
                    break;
                case "Module":
                    questionVM.GetQuestionsByModulesId(str.Split(' ').Select(int.Parse).ToArray());
                    break;
                case "Theme":
                    questionVM.GetQuestionsByThemesId(str.Split(' ').Select(int.Parse).ToArray());
                    break;
                default:
                    break;
            }

            qNotify = new QuestionNotify(questionVM.Entities.ToArray());
            DataContext = qNotify;
            ViewQuestion();
        }

        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            
            switch (qNotify.CurentQuestion.Type)
            {
                case 0:
                    Answer[] l = new Answer[questionAnswers.SelectedItems.Count];
                    questionAnswers.SelectedItems.CopyTo(l, 0);
                    if (!qNotify.NextQuestion(l))
                    {
                        TestFinish();
                        return;
                    }
                    ViewQuestion();
                    break;
                case 1:
                    if(!qNotify.NextQuestion(questionAnswers.SelectedItem as Answer))
                    {
                        TestFinish();
                        return;
                    }
                    ViewQuestion();
                    break;
                case 2:
                    if(!qNotify.NextQuestion(TextAnswer.Text))
                    {
                        TestFinish();
                        return;
                    }
                    ViewQuestion();
                    break;
            }
        }

        private void ViewQuestion()
        {
            switch (qNotify.CurentQuestion.Type)
            {
                case 0:
                    questionAnswers.ItemContainerStyle = Resources["ListBoxItemStyle1"] as Style;
                    HideTextBoxAnswer();
                    break;
                case 1:
                    questionAnswers.ItemContainerStyle = Resources["ListBoxItemStyle2"] as Style;
                    HideTextBoxAnswer();
                    break;
                case 2:
                    ShowTextBoxAnswer();
                    break;
            }
        }

        private void ShowTextBoxAnswer()
        {
            questionAnswers.Visibility = Visibility.Collapsed;
            TextAnswer.Visibility = Visibility.Visible;
        }

        private void HideTextBoxAnswer()
        {
            questionAnswers.Visibility = Visibility.Visible;
            TextAnswer.Visibility = Visibility.Collapsed;
        }

        private void TestFinish()
        {
            MessageBox.Show(String.Format("{0} вірних, з {1} питань",qNotify.TrueQuestion, qNotify.NumberQuestion),"Результат", MessageBoxButton.OK);
            TestViewModel testVM = new TestViewModel();
            testVM.AddTest(new Test(type, str, qNotify.NumberQuestion, qNotify.TrueQuestion, DateTime.Now));
            NavigationService.Navigate(new Uri("/View/CourseView.xaml", UriKind.Relative));
        }
    }

    
}