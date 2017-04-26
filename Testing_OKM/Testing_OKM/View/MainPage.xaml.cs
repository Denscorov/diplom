using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Testing_OKM.ViewModel;
using Testing_OKM.Model;
using System.Diagnostics;

namespace Testing_OKM
{
    public partial class MainPage : PhoneApplicationPage
    {
        CourseDataAccess dataAccess;

        public MainPage()
        {
            InitializeComponent();
            dataAccess = new CourseDataAccess();
            dataAccess.GetCourses();
            this.DataContext = dataAccess;
        }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    ListCourses.SelectedItem = null;
        //}

        //private void ListCourses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    var course = ListCourses.SelectedItem as Course;
        //    if (course != null)
        //    {
        //        NavigationService.Navigate(new Uri("/View/ModulePage.xaml?CourseId=" + course.Id + "&CourseName=" + course.Name, UriKind.Relative));
        //    }
        //}

        //private void startTesting_Click(object sender, RoutedEventArgs e)
        //{
        //    var menuItem = sender as MenuItem;
        //    var course = menuItem.DataContext as Course;

        //    MessageBox.Show("Start testing " + course.Name);

        //    NavigationService.Navigate(new Uri("/View/TestingPage.xaml?TypeTest=" + typeof(Course) + "&ObjectId=" + course.Id, UriKind.Relative));
        //}


        //public void AddQuestionToTheme()
        //{
        //    Debug.WriteLine("Start write");

            


        //    Debug.WriteLine("Start write");
        //}
    }
}