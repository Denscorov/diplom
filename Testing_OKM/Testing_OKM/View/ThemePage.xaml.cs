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
    public partial class ThemePage : PhoneApplicationPage
    {
        ThemeDataAccess dataAccess;

        QuestionDataAccess dataAccessQ;

        public ThemePage()
        {
            InitializeComponent();
            dataAccess = new ThemeDataAccess();
            dataAccessQ = new QuestionDataAccess();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ListThemes.SelectedItem = null;

            base.OnNavigatedTo(e);

            string ModuleId = "";
            string ModuleName = "";

            if (NavigationContext.QueryString.TryGetValue("ModuleName", out ModuleName))
                Title.Text += ModuleName;

            if (NavigationContext.QueryString.TryGetValue("ModuleId", out ModuleId))
            {
                dataAccess.GetThemes(Convert.ToInt32(ModuleId));
                this.DataContext = dataAccess;
            }

            foreach (var theme in dataAccess.Themes)
            {
                dataAccessQ.AddTestQuestionsToTheme(theme);

                dataAccessQ.AddedAnswerToQuestion(theme);
            }
        }

        private void ListThemes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var theme = ListThemes.SelectedItem as Theme;
            if (theme != null)
            {
                MessageBox.Show("Start testing " + theme.Name);
                  NavigationService.Navigate(new Uri("/View/TestingPage.xaml?TypeTest=" + typeof(Theme) + "&ObjectId=" + theme.Id, UriKind.Relative));
            }
        }
    }
}