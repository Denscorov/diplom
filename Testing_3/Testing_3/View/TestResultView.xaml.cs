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
using System.IO;
using System.Text;
using Testing_3.Model;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Testing_3.View
{
    public partial class TestResultView : PhoneApplicationPage
    {
        TestViewModel testVM;

        ApplicationBarIconButton load = new ApplicationBarIconButton() { IconUri = new Uri("/Assets/AppBar/share.png", UriKind.Relative), IsEnabled = false, Text = "вивантажити" };

        Student st;

        SQLite.Net.SQLiteConnection database;

        public TestResultView()
        {
            InitializeComponent();
            testVM = new TestViewModel();
            testVM.GetAllTests();
            DataContext = testVM;

            database = DBConnection.GetCoonection();
            try
            {
                st = database.Table<Student>().Where(s => s.Is_Active).Single();
                ApplicationBar.Buttons.Add(load);
                load.Click += Load_Click;
            }
            catch (Exception)
            {
            }
        }

        private async void Load_Click(object sender, EventArgs e)
        {
            List<int> t = new List<int>();
            foreach (var item in TestResultList.SelectedItems)
            {
                t.Add((item as Test).Id);
            }
            List<Test> ttt = database.Table<Test>().Where(tt => t.Contains(tt.Id)).ToList();
            HttpRequestSend http = new HttpRequestSend(App.IP_ADDRESS, "/api/students/" + st.Login + "/auths/" + st.Password);
            var s = await http.GetRequestJsonAsync<Student>();
            ttt.ForEach((i) => {
                i.StudentId = s.Id;
            });
            string data = Newtonsoft.Json.JsonConvert.SerializeObject(ttt);
            HttpRequestSend req = new HttpRequestSend(App.IP_ADDRESS, "/api/tests/arrays");
            testVM.IsBusy = true;
            testVM.Message = "Вивантаження результатів...";
            var w = await req.PostRequest(data);
            testVM.Message = "Вивантаження завершене!!!";
            testVM.IsBusy = false;
        }

        private void Client_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            MessageBox.Show(e.Result);
        }

        private void select_Click(object sender, EventArgs e)
        {
            if (TestResultList.IsSelectionEnabled)
            {
                TestResultList.IsSelectionEnabled = false;
            }
            else
            {
                TestResultList.IsSelectionEnabled = true;
            }
        }

        private void sort_by_type_Click(object sender, EventArgs e)
        {
            testVM.SortBytype();
        }

        private void sort_by_date_Click(object sender, EventArgs e)
        {
            testVM.SortByDate();
        }

        

        private void TestResultList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TestResultList.SelectedItems.Count > 0)
            {
                if (ApplicationBar.Buttons.Count == 2)
                {
                    load.IsEnabled = true;
                }
            }else
            {
                if (ApplicationBar.Buttons.Count == 2)
                {
                    load.IsEnabled = false;
                }
            }
        }
    }
}