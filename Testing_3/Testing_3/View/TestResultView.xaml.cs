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
        TestViewModel testVm;

        ApplicationBarIconButton load = new ApplicationBarIconButton() { IconUri = new Uri("/Assets/AppBar/share.png", UriKind.Relative), IsEnabled = false, Text = "вивантажити" };

        Student st;

        SQLite.Net.SQLiteConnection database;

        public TestResultView()
        {
            InitializeComponent();
            testVm = new TestViewModel();
            testVm.GetAllTests();
            DataContext = testVm;

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

        private void Load_Click(object sender, EventArgs e)
        {
            //JsonWebClient client = new JsonWebClient();
            //try
            //{
            //    var url = App.IP_ADDRESS + "/api/students/" + st.Login + "/auths/" + st.Password;
            //    var resp = await client.DoRequestJsonAsync<Student>(url);
            //    if (resp != null)
            //    {
            //post(App.IP_ADDRESS + "/api/tests/arrays");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}

            //post(App.IP_ADDRESS + "/api/");
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
            testVm.SortBytype();
        }

        private void sort_by_date_Click(object sender, EventArgs e)
        {
            testVm.SortByDate();
        }

        public async void post(string uri)
        {
            var database = DBConnection.GetCoonection();
            List<Test> t = new List<Test>();
            foreach (var item in TestResultList.SelectedItems)
            {
                var o = database.Table<Test>().Where(tt => tt.Id == (item as Test).Id).Single();
                t.Add(o);
            }


            HttpWebRequest httpRequest = WebRequest.Create(uri) as HttpWebRequest;
            await GetHttpPostResponse(httpRequest, Newtonsoft.Json.JsonConvert.SerializeObject(t));
            
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

        internal static async Task<string> GetHttpPostResponse(HttpWebRequest request, string postData)
        {
            string received = null;

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            byte[] requestBody = Encoding.UTF8.GetBytes(postData);

            using (var postStream = await request.GetRequestStreamAsync())
            {
                await postStream.WriteAsync(requestBody, 0, requestBody.Length);
            }

            try
            {
                var response = (HttpWebResponse)await request.GetResponseAsync();
                if (response != null)
                {
                    var reader = new StreamReader(response.GetResponseStream());
                    received = await reader.ReadToEndAsync();
                }
            }
            catch (WebException we)
            {
                var reader = new StreamReader(we.Response.GetResponseStream());
                string responseString = reader.ReadToEnd();
                Debug.WriteLine(responseString);
                return responseString;
            }

            return received;
        }
    }
}