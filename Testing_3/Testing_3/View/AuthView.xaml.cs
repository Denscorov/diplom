﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
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
            var url = "/api/students/" + login.Text + "/auths/" + password.Password;

            if (login.Text == "" || password.Password == "")
            {
                MessageBox.Show("Логін та пароль маютьбути ведені!!!");
            }
            else
            {
                HttpRequestSend http = new HttpRequestSend(App.IP_ADDRESS, url);
                try
                {
                    progressIndicator.IsVisible = true;
                    progressIndicator.IsIndeterminate = true;
                    progressIndicator.Text = "Авторизація";
                    var student = await http.GetRequestJsonAsync<Student>();
                    if (student != null)
                    {
                        MessageBox.Show("Авторизація успішно виконана");
                        var database = DBConnection.GetCoonection();
                        database.Insert(student);
                        App.STUD_ID = student.Id;
                        progressIndicator.IsVisible = false;
                        progressIndicator.IsIndeterminate = false;
                        NavigationService.Navigate(new Uri("/View/CourseView.xaml", UriKind.Relative));
                    }
                }
                catch (WebException ex)
                {
                    MessageBox.Show("Користувача з таким логіном чи паролем не існує, або перервано з'єднання!!!");
                }
            }
        }
    }
}