using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Test_1.Resources;
using SQLite.Net;
using Test_1.Model;

namespace Test_1
{
    public partial class MainPage : PhoneApplicationPage
    {
        DataAccess dataAccess;
        public MainPage()
        {
            InitializeComponent();
            dataAccess = new DataAccess();
            this.DataContext = dataAccess;
        }

        private void addUser_Click(object sender, RoutedEventArgs e)
        {
            dataAccess.InsertUser(new User(userName.Text));
            
        }

        private void delete_Click(object sender, EventArgs e)
        {
            var user = userList.SelectedItem as User;
            if (user != null)
            {
                dataAccess.DeleteUser(user);
            }
        }

        private void addBook_Click(object sender, EventArgs e)
        {
            var user = userList.SelectedItem as User;
            if (user != null)
            {
                dataAccess.AddBookToUser(user, new Book("book X"), new Book("book Y"));
            }
        }

        private void show_Click(object sender, EventArgs e)
        {
            var user = userList.SelectedItem as User;
            if (user != null)
            {
                var mess = "id: " + user.Id + "\n" +
                "name: " + user.Name + "\n" +
                "books count: " + user.Books.Count;
                MessageBox.Show(mess, "User info", MessageBoxButton.OK);
            }
        }

        private void addFriend_Click(object sender, EventArgs e)
        {
            var user = userList.SelectedItem as User;
            userList.SelectedItems.Remove(user);
            var friends = new List<User>();
            foreach (var friend in userList.SelectedItems)
            {
                friends.Add(friend as User);
            }
            dataAccess.AddFriend(user, friends);
        }
    }
}