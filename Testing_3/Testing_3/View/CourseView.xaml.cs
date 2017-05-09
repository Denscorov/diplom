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
    public partial class CourseView : PhoneApplicationPage
    {
        CourseViewModel courseVM;

        ApplicationBarIconButton testing = new ApplicationBarIconButton() { IconUri = new Uri("/Assets/AppBar/check.png", UriKind.Relative), IsEnabled = true, Text = "тестування" };
        ApplicationBarIconButton selected = new ApplicationBarIconButton() { IconUri = new Uri("/Toolkit.Content/ApplicationBar.Select.png", UriKind.Relative), IsEnabled = true, Text = "вибрати" };

        public CourseView()
        {
            InitializeComponent();
            courseVM = new CourseViewModel();
            courseVM.GetAllCourses();
            DataContext = courseVM;

            testing.Click += Testing_Click;
        }

        private void CourseList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CourseList.SelectedItems.Count > 0)
            {
                if (ApplicationBar.Buttons.Count == 1)
                {
                    ApplicationBar.Buttons.Insert(1, testing);
                }
                (ApplicationBar.MenuItems[0] as ApplicationBarMenuItem).IsEnabled = true;
            }
            else
            {
                ApplicationBar.Buttons.RemoveAt(1);
                (ApplicationBar.MenuItems[0] as ApplicationBarMenuItem).IsEnabled = false;
            }
        }

        private void show_modules_bar_Click(object sender, EventArgs e)
        {
            var ids = new int[CourseList.SelectedItems.Count];
            for (int i = 0; i < CourseList.SelectedItems.Count; i++)
            {
                ids[i] = (CourseList.SelectedItems[i] as Course).Id;
            }
            NavigationService.Navigate(new Uri("/View/ModuleView.xaml?str=" + String.Join(" ", ids), UriKind.Relative));
        }

        private void Testing_Click(object sender, EventArgs e)
        {
            var ids = new int[CourseList.SelectedItems.Count];
            for (int i = 0; i < CourseList.SelectedItems.Count; i++)
            {
                ids[i] = (CourseList.SelectedItems[i] as Course).Id;
            }
            NavigationService.Navigate(new Uri("/View/TestingView.xaml?type=Course&str=" + String.Join(" ", ids), UriKind.Relative));
        }

        private void select_Click(object sender, EventArgs e)
        {
            if (CourseList.IsSelectionEnabled)
            {
                CourseList.IsSelectionEnabled = false;
            }
            else
            {
                CourseList.IsSelectionEnabled = true;
            }
        }
    }
}