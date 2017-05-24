using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Web.Http;
using Newtonsoft.Json;
using Testing_3.Model;

namespace Testing_3.View
{
    public partial class AuthView : PhoneApplicationPage
    {
        public AuthView()
        {
            InitializeComponent();
        }

        private async void auth_Click(object sender, RoutedEventArgs e)
        {
            var url = App.IP_ADDRESS + "/api/students/"+login.Text+"/auths/" + password.Text;

            if (login.Text == "" || password.Text == "")
            {
                MessageBox.Show("Логін та пароль маютьбути ведені!!!");
                return;
            }
            JsonWebClient client = new JsonWebClient();
            try
            {
                MessageBox.Show(url);
                var resp = await client.DoRequestJsonAsync<Student>(url);
                if (resp != null)
                {
                    MessageBox.Show("Авторизація успішно виконана");
                    var database = DBConnection.GetCoonection();
                    database.Insert(resp);
                    App.STUD_ID = resp.Id;
                    NavigationService.Navigate(new Uri("/View/CourseView.xaml", UriKind.Relative));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }


    }
}