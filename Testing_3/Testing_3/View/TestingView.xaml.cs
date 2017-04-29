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
        QuestionViewModel questionVM;

        string type = "";
        string obj = "";
        string str = "";

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

            questionText.Text = questionVM.Entities.Count.ToString();
        }
    }
}