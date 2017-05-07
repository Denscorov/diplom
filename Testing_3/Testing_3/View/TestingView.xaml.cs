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
        string obj = "";
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
            ViewQuestion();
        }

        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            
            switch (qNotify.CurentQuestion.Type)
            {
                case 0:
                    Answer[] l = new Answer[questionAnswers.SelectedItems.Count];
                    questionAnswers.SelectedItems.CopyTo(l, 0);
                    qNotify.NextQuestion(l);
                    ViewQuestion();
                    break;
                case 1:
                    qNotify.NextQuestion(questionAnswers.SelectedItem as Answer);
                    ViewQuestion();
                    break;
                case 2:
                    qNotify.NextQuestion(TextAnswer.Text);
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
    }

    class QuestionNotify : INotifyPropertyChanged
    {
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

        int index = 0;

        Question[] questions;

        Question curentQuestion;

        public Question CurentQuestion
        {
            set
            {
                if (!EquivalentQuestion.Contains(value))
                {
                    curentQuestion = value;
                    EquivalentQuestion.AddRange(CurentQuestion.EquivalentQuestion);
                    NotifyPropertyChanged();
                }
                else
                {
                    SkipQuestion();
                }
            }
            get
            {
                return curentQuestion;
            }
        }

        List<Question> EquivalentQuestion;

        public QuestionNotify(Question[] questions)
        {
            EquivalentQuestion = new List<Question>();
            this.questions = questions;
            CurentQuestion = questions[index];
            NumberQuestion++;
            index++;
        }

        public bool NextQuestion(string textAnswer)
        {
            if (CurentQuestion.Answers.Count > 0)
            {
                var i = ScoreSharp.score(CurentQuestion.Answers[0].Text, textAnswer);
            }

            if (NumberQuestion < questions.Count() - 1)
            {
                CurentQuestion = questions[index++];
                NumberQuestion++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NextQuestion(Answer answer)
        {
            foreach (var ans in CurentQuestion.Answers)
            {
                if (ans.Corect && ans.Id == answer.Id)
                {
                    TrueQuestion++;
                }
            }

            if (NumberQuestion < questions.Count() - 1)
            {
                CurentQuestion = questions[index++];
                NumberQuestion++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NextQuestion(Answer[] answers)
        {
            var i = CurentQuestion.Answers.Where(a => a.Corect).Count();
            var j = answers.Where(a => a.Corect == true).Count();

            if (i != 0 && j != 0 && i == j)
            {
                TrueQuestion++;
            }

            if (NumberQuestion < questions.Count() - 1)
            {
                CurentQuestion = questions[index++];
                NumberQuestion++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SkipQuestion()
        {
            CurentQuestion = questions[index++];
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}