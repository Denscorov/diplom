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

namespace Testing_3.View
{
    public partial class TestingView : PhoneApplicationPage
    {
        QuestionViewModel questionVM;

        string type = "";
        string obj = "";
        string str = "";

        QuestionNotify qNotify;
        //int index = 0;

        //public int qNumber = 0;
        //public int trueQuestion = 0;

        public TestingView()
        {
            InitializeComponent();
            questionVM = new QuestionViewModel();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            NavigationContext.QueryString.TryGetValue("type", out type);
            NavigationContext.QueryString.TryGetValue("obj", out obj);
            NavigationContext.QueryString.TryGetValue("str", out str);

            switch (obj)
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
            
        }

        //public void SetQuestion()
        //{
        //    if (index <= questionVM.Entities.Count - 1)
        //    {
        //        Question question = questionVM.Entities[index];
        //        questionText.Text = question.Text;

        //        switch (question.Type)
        //        {
        //            case 0:
        //                HideTextAnswer();
        //                questionAnswers.ItemTemplate = Resources["TypeQuestion0"] as DataTemplate;
        //                break;
        //            case 1:
        //                HideTextAnswer();
        //                questionAnswers.ItemTemplate = Resources["TypeQuestion1"] as DataTemplate;
        //                break;
        //            case 2:
        //                ShowTextAnswer();
        //                break;
        //            default:
        //                break;
        //        }
        //        questionAnswers.ItemsSource = question.Answers;
        //        index++;
        //        qNumber++;
        //        UpdateQNumber();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Тест завершено");
        //    }
        //}

        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            //SetQuestion();
        }

        //private void ShowTextAnswer()
        //{
        //    questionAnswers.Visibility = Visibility.Collapsed;
        //    TextAnswer.Visibility = Visibility.Visible;
        //}

        //private void HideTextAnswer()
        //{
        //    questionAnswers.Visibility = Visibility.Visible;
        //    TextAnswer.Visibility = Visibility.Collapsed;
        //}

        //public void UpdateQNumber()
        //{
        //    QuestionNumber.Text = qNumber.ToString();
        //}

        //public void UpdateTrueQuestion()
        //{
        //    TrueQuestionNumber.Text = trueQuestion.ToString();
        //}
    }

    class QuestionNotify : INotifyPropertyChanged
    {
        int index = 0;
        int trueQuestion = 0;
        public int TrueQuestion
        {
            set
            {
                trueQuestion = value;
                NotifyPropertyChanged();
            }
            get
            {
                return trueQuestion;
            }
        }

        int numberQuestion = 0;
        public int NumberQuestion
        {
            set
            {
                numberQuestion = value;
                NotifyPropertyChanged();
            }
            get
            {
                return numberQuestion;
            }
        }

        Question[] questions;

        Question curentQuestion;

        public Question CurentQuestion
        {
            set
            {
                curentQuestion = value;
                NotifyPropertyChanged();
            }
            get
            {
                return curentQuestion;
            }
        }

        public QuestionNotify(Question[] questions)
        {
            this.questions = questions;
            CurentQuestion = questions[index];
            NumberQuestion++;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}