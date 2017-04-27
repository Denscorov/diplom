using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Testing_3.View
{
    public partial class TestingView : PhoneApplicationPage
    {
        string type = "";
        string obj = "";
        string str = "";

        public TestingView()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            NavigationContext.QueryString.TryGetValue("type", out type);
            NavigationContext.QueryString.TryGetValue("obj", out obj);
            NavigationContext.QueryString.TryGetValue("str", out str);

            questionText.Text = type + obj + str;
        }
    }
}