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

        public CourseView()
        {
            InitializeComponent();
            courseVM = new CourseViewModel();
            courseVM.GetAllCourses();
            DataContext = courseVM;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CourseList.SelectedIndex = -1;
        }

        private void select_all_Click(object sender, EventArgs e)
        {
            CourseList.SelectAll();
        }

        private void unselect_Click(object sender, EventArgs e)
        {
            CourseList.SelectedIndex = -1;
        }

        private void CourseList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CourseList.SelectedItems.Count > 0)
            {
                (ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled = true;
            }
            else
            {
                (ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled = false;
            }
        }

        private void show_modules_bar_Click(object sender, EventArgs e)
        {
            var ids = new int[CourseList.SelectedItems.Count];
            for (int i = 0; i < CourseList.SelectedItems.Count; i++)
            {
                ids[i] = (CourseList.SelectedItems[i] as Course).Id;
            }
            NavigationService.Navigate(new Uri("/View/ModuleView.xaml?type=many&str=" + String.Join(" ", ids), UriKind.Relative));
        }

        private void show_modules_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            var course = item.DataContext as Course;
            NavigationService.Navigate(new Uri("/View/ModuleView.xaml?type=one&str=" + course.Id, UriKind.Relative));
        }

        private void start_testing_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            var course = item.DataContext as Course;
            NavigationService.Navigate(new Uri("/View/TestingView.xaml?obj=Course&str="+ course.Id, UriKind.Relative));
        }

        private void Testing_Click(object sender, EventArgs e)
        {
            var ids = new int[CourseList.SelectedItems.Count];
            for (int i = 0; i < CourseList.SelectedItems.Count; i++)
            {
                ids[i] = (CourseList.SelectedItems[i] as Course).Id;
            }
            NavigationService.Navigate(new Uri("/View/TestingView.xaml?obj=Course&str=" + String.Join(" ", ids), UriKind.Relative));
        }
    }
}