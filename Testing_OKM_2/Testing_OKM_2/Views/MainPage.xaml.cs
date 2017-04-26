using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Testing_OKM_2.Resources;
using Testing_OKM_2.Controllers;
using System.Windows.Controls.Primitives;
using Testing_OKM_2.Model;

namespace Testing_OKM_2.Views
{
    public partial class MainPage : PhoneApplicationPage
    {
        CourseController courseController;

        public MainPage()
        {
            InitializeComponent();
            courseController = new CourseController();
            DataContext = courseController;
            addPopup.Opened += AddPopup_Opened;
        }

        private void AddPopup_Opened(object sender, EventArgs e)
        {
            if ((sender as Popup).IsOpen)
            {
                (ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled = false;
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (!addPopup.IsOpen)
            {
                addPopup.IsOpen = true;
                PopupName.Focus();
            }
        }

        private void PopupButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            courseController.InsertEntity(new Model.Course(PopupName.Text));
            PopupName.Text = "";
            addPopup.IsOpen = false;
            (ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled = true;
        }
        private void addModule_Click(object sender, EventArgs e)
        {
            var array = new Course[ListItems.SelectedItems.Count];
            ListItems.SelectedItems.CopyTo(array, 0);
            foreach (var course in array)
            {
                courseController.AddModule(course as Course, new Module("module for course id: " + (course as Course).Id));
            }
        }

        private void ListItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                (ApplicationBar.MenuItems[0] as ApplicationBarMenuItem).IsEnabled = true;
                (ApplicationBar.MenuItems[1] as ApplicationBarMenuItem).IsEnabled = true;
            }
            else
            {
                (ApplicationBar.MenuItems[0] as ApplicationBarMenuItem).IsEnabled = false;
                (ApplicationBar.MenuItems[1] as ApplicationBarMenuItem).IsEnabled = true;
            }
        }

        private void startTesting_Click(object sender, EventArgs e)
        {

        }
    }
}