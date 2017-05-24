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
            //var url = "192.168.0.101/api/students/" +  login.Text + "/auths/" + password.Text;
            var url = "https://httpbin.org/get";
            JsonWebClient client = new JsonWebClient();
            var resp = await client.DoRequestAsync(url);
            string result = resp.ReadToEnd();
            MessageBox.Show(result);
        }


    }
}