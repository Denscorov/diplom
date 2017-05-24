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
using System.Windows.Threading;

namespace Testing_3.View
{
    public partial class TestingView : PhoneApplicationPage
    {
        QuestionViewModel questionVM;
        TestViewModel testVM;

        string type = "";
        string str = "";

        QuestionNotify qNotify;

        DispatcherTimer timer;

        public TestingView()
        {
            InitializeComponent();
            questionVM = new QuestionViewModel();
            testVM = new TestViewModel();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            qNotify.AddTimer(TimeSpan.FromSeconds(1));
            textTimer.Text = qNotify.Timer.ToString();
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

            if (questionVM.Entities.Count == 0)
            {
                MessageBox.Show("Питання відсутні", "Увага!!!", MessageBoxButton.OK);
                NavigationService.Navigate(new Uri("/View/CourseView.xaml", UriKind.Relative));
                return;
            }

            qNotify = new QuestionNotify(questionVM.Entities.ToArray());
            DataContext = qNotify;
            ViewQuestion();

            //MessageBox.Show();
            timer.Start();
            
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            if (MessageBox.Show("Завершити тест без збереження результатів???", "Увага!!!", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            
            switch (qNotify.CurentQuestion.Type)
            {
                case 0:
                    if (questionAnswers.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("Виберіть правельну відповідь", "Увага!", MessageBoxButton.OK);
                        return;
                    }
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
                    if (questionAnswers.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("Виберіть правельну відповідь", "Увага!", MessageBoxButton.OK);
                        return;
                    }
                    if(!qNotify.NextQuestion(questionAnswers.SelectedItem as Answer))
                    {
                        TestFinish();
                        return;
                    }
                    ViewQuestion();
                    break;
                case 2:
                    if (TextAnswer.Text == "")
                    {
                        MessageBox.Show("Ведіть правельну відповідь", "Увага!", MessageBoxButton.OK);
                        return;
                    }
                    if(!qNotify.NextQuestion(TextAnswer.Text))
                    {
                        TestFinish();
                        return;
                    }
                    TextAnswer.Text = "";
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
            timer.Stop();
            MessageBox.Show(string.Format("{0} вірних, з {1} питань",qNotify.TrueQuestion, qNotify.NumberQuestion),"Результат", MessageBoxButton.OK);

            var database = DBConnection.GetCoonection();
            Student st = null;
            try
            {
                st = database.Table<Student>().Where(s => s.Is_Active).Single();
            }
            catch (Exception)
            {
            }

            testVM.AddTest(new Test(type, questionVM.GetNames(type, str.Split(' ').Select(int.Parse).ToArray()), qNotify.NumberQuestion, qNotify.TrueQuestion, DateTime.Now.ToShortTimeString(), DateTime.Now.ToShortDateString(), qNotify.Timer.ToString(), st));
            NavigationService.RemoveBackEntry();
            NavigationService.Navigate(new Uri("/View/CourseView.xaml", UriKind.Relative));
        }
    }

    
}