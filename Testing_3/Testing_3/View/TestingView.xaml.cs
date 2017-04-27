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

namespace Testing_3.View
{
    public partial class TestingView : PhoneApplicationPage
    {
        int index = 0;
        int trueAnswers = 0;
        string type = "";
        string obj = "";
        string str = "";

        List<Question> EquivalentQuestion = new List<Question>();
        List<Answer> ans = new List<Answer>();

        QuestionViewModel questionVM;

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

            switch (type)
            {
                case "one":
                    switch (obj)
                    {
                        case "Course":
                            questionVM.GetQuestionsByCourseId(int.Parse(str));
                            break;
                        case "Module":
                            questionVM.GetQuestionsByModuleId(int.Parse(str));
                            break;
                        case "Theme":
                            questionVM.GetQuestionsByThemeId(int.Parse(str));
                            break;
                        default:
                            break;
                    }
                    SetQuestion();
                    break;
                case "many":
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
                    SetQuestion();
                    break;
                default:
                    break;
            }
        }

        public void SetQuestion()
        {
            if (index < questionVM.Entities.Count)
            {
                Question question = questionVM.Entities[index];
                if (!EquivalentQuestion.Contains(question))
                {
                    EquivalentQuestion.AddRange(question.EquivalentQuestion);
                    questionText.Text = question.Text;
                    questionAnswers.ItemsSource = question.Answers;
                    switch (question.Type)
                    {
                        case 0:
                            questionAnswers.ItemTemplate = Resources["TypeQuestion0"] as DataTemplate;
                            break;
                        case 1:
                            questionAnswers.ItemTemplate = Resources["TypeQuestion1"] as DataTemplate;
                            break;
                        case 2:
                            questionAnswers.ItemTemplate = Resources["TypeQuestion2"] as DataTemplate;
                            break;
                    }
                    ans = question.Answers;
                    ans.ForEach(a => a.Corect = false);
                    questionAnswers.ItemsSource = ans;
                }
                index++;
            }
        }

        public void UpdateNumber()
        {
            QuestionNumber.Text = index.ToString();
        }

        public void AddTrueAnswer()
        {
            trueAnswers++;
        }
        List<object> a;
        private void NextQuestion_Click(object sender, RoutedEventArgs e)
        {
            SetQuestion();
            a = questionAnswers.Items.ToList();
        }
    }
}