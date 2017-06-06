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
using Windows.Web.Http;

namespace Testing_3.View
{
    public partial class CourseView : PhoneApplicationPage
    {
        CourseViewModel courseVM;

        ApplicationBarIconButton testing = new ApplicationBarIconButton() { IconUri = new Uri("/Assets/AppBar/check.png", UriKind.Relative), IsEnabled = true, Text = "тестування" };
        ApplicationBarIconButton selected = new ApplicationBarIconButton() { IconUri = new Uri("/Toolkit.Content/ApplicationBar.Select.png", UriKind.Relative), IsEnabled = true, Text = "вибрати" };

        SQLite.Net.SQLiteConnection database = DBConnection.GetCoonection();
        Student st;

        public CourseView()
        {
            InitializeComponent();
            courseVM = new CourseViewModel();
            courseVM.GetAllCourses();
            DataContext = courseVM;

            testing.Click += Testing_Click;
            try
            {
                st = database.Table<Student>().Where(s => s.Is_Active).Single();
                App.STUD_ID = st.Id;
                (ApplicationBar.MenuItems[ApplicationBar.MenuItems.Count - 1] as ApplicationBarMenuItem).Text = "Вихід";
                (ApplicationBar.MenuItems[ApplicationBar.MenuItems.Count - 1] as ApplicationBarMenuItem).Click += CourseView_Click;
            }
            catch (Exception)
            {
            }
        }

        private async void CourseView_Click(object sender, EventArgs e)
        {
            try
            {
                HttpRequestSend http = new HttpRequestSend(App.IP_ADDRESS, "/api/students/" + st.Login + "/auths/" + st.Password);
                var s = await http.GetRequestJsonAsync<Student>();
                if (!NetworkConnection.checkNetworkConnection())
                {
                    MessageBox.Show("Відсутнє підключення!!!");
                    return;
                }
                http = new HttpRequestSend(App.IP_ADDRESS, "/api/students/" + s.Id + "/actives/0");
                await http.GetRequestJsonAsync<Student>();
                database.Delete(st);
                App.STUD_ID = 0;
                (ApplicationBar.MenuItems[ApplicationBar.MenuItems.Count - 1] as ApplicationBarMenuItem).Text = "Авторизуватись";
                (ApplicationBar.MenuItems[ApplicationBar.MenuItems.Count - 1] as ApplicationBarMenuItem).Click += auth_Click;
            }
            catch (WebException ex)
            {
                MessageBox.Show("Відсутнє підключення до сервера!!!");
            }
            
            
        }

        private void CourseList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CourseList.SelectedItems.Count > 0)
            {
                if (ApplicationBar.Buttons.Count == 3)
                {
                    ApplicationBar.Buttons.Insert(3, testing);
                }
                (ApplicationBar.MenuItems[0] as ApplicationBarMenuItem).IsEnabled = true;
            }
            else
            {
                ApplicationBar.Buttons.RemoveAt(3);
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

        private void show_results_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/TestResultView.xaml", UriKind.Relative));
        }

        private void auth_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/AuthView.xaml", UriKind.Relative));
        }

        private async void load_db_Click(object sender, EventArgs e)
        {
            courseVM.IsBusy = true;
            try
            {
                HttpRequestSend http = new HttpRequestSend(App.IP_ADDRESS, "/api/courses");
                if (!NetworkConnection.checkNetworkConnection())
                {
                    courseVM.IsBusy = false;
                    MessageBox.Show("Відсутнє підключення");
                    return;
                }
                var list = await http.GetRequestJsonAsync<List<Course>>();
                courseVM.removeAll();
                courseVM.InsertList(list);
                courseVM.IsBusy = false;
                MessageBox.Show("База даних оновлена!!!");
            }
            catch (WebException ex)
            {
                courseVM.IsBusy = false;
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void setings_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/View/SetingsView.xaml", UriKind.Relative));
        }
    }
}