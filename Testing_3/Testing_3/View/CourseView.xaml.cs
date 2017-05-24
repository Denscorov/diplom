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

        private void CourseView_Click(object sender, EventArgs e)
        {
            database.Delete(st);
            App.STUD_ID = 0;
            (ApplicationBar.MenuItems[ApplicationBar.MenuItems.Count - 1] as ApplicationBarMenuItem).Text = "Авторизуватись";
            (ApplicationBar.MenuItems[ApplicationBar.MenuItems.Count - 1] as ApplicationBarMenuItem).Click += auth_Click;


        }

        private void CourseList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CourseList.SelectedItems.Count > 0)
            {
                if (ApplicationBar.Buttons.Count == 2)
                {
                    ApplicationBar.Buttons.Insert(2, testing);
                }
                (ApplicationBar.MenuItems[0] as ApplicationBarMenuItem).IsEnabled = true;
            }
            else
            {
                ApplicationBar.Buttons.RemoveAt(2);
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
            LayoutRoot.IsHitTestVisible = false;
           
            JsonWebClient client = new JsonWebClient();
            try
            {
                var url = App.IP_ADDRESS + "/api/courses";
                var resp = await client.DoRequestJsonAsync<List<Course>>(url);
                if (resp != null)
                {
                    courseVM.removeAll();
                    QuestionViewModel questionVM = new QuestionViewModel();
                    questionVM.removeAll();
                    courseVM.InsertList(resp);
                    MessageBox.Show("Базу питань оновлено");
                    LayoutRoot.IsHitTestVisible = true;
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                LayoutRoot.IsHitTestVisible = true;
            }
        }
        
    }
}