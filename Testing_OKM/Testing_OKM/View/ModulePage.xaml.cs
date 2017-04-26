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
    public partial class ModulePage : PhoneApplicationPage
    {
        ModuleDataAccess dataAccess;

        public ModulePage()
        {
            InitializeComponent();
            dataAccess = new ModuleDataAccess();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ListModules.SelectedItem = null;

            base.OnNavigatedTo(e);

            string CourseId = "";
            string CourseName = "";

            if (NavigationContext.QueryString.TryGetValue("CourseName", out CourseName))
                Title.Text += CourseName;

            if (NavigationContext.QueryString.TryGetValue("CourseId", out CourseId))
            {
                dataAccess.GetModules(Convert.ToInt32(CourseId));
                dataAccess.AddedThemeToModule();
                this.DataContext = dataAccess;
            }
        }

        private void ListModules_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var module = ListModules.SelectedItem as Module;
            if (module != null)
            {
                NavigationService.Navigate(new Uri("/View/ThemePage.xaml?ModuleId=" + module.Id + "&ModuleName=" + module.Name, UriKind.Relative));
            }
        }

        private void startTesting_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            var module = menuItem.DataContext as Module;

            MessageBox.Show("Start testing " + module.Name);

            NavigationService.Navigate(new Uri("/View/TestingPage.xaml?TypeTest=" + typeof(Module) + "&ObjectId=" + module.Id, UriKind.Relative));
        }
    }
}