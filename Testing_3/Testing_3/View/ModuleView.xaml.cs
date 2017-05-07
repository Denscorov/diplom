﻿using System;
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
    public partial class ModuleView : PhoneApplicationPage
    {
        ModuleViewModel moduleVM;

        ApplicationBarIconButton testing = new ApplicationBarIconButton() { IconUri = new Uri("/Assets/AppBar/check.png", UriKind.Relative), IsEnabled = true, Text = "тестування" };
        ApplicationBarIconButton selected = new ApplicationBarIconButton() { IconUri = new Uri("/Toolkit.Content/ApplicationBar.Select.png", UriKind.Relative), IsEnabled = true, Text = "вибрати" };

        string type = "";
        string str = "";
        public ModuleView()
        {
            InitializeComponent();
            moduleVM = new ModuleViewModel();
            DataContext = moduleVM;

            testing.Click += Testing_Click;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            NavigationContext.QueryString.TryGetValue("type", out type);
            NavigationContext.QueryString.TryGetValue("str", out str);
            if (type == "many")
            {
                moduleVM.GetModulesByCoursesId(str.Split(' ').Select(int.Parse).ToArray());
            }
            else
            {
                moduleVM.GetModulesByCourseId(int.Parse(str));
            }
        }

        private void ModuleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ModuleList.SelectedItems.Count > 0)
            {
                if (ApplicationBar.Buttons.Count == 1)
                {
                    ApplicationBar.Buttons.Insert(1, testing);
                }
            }
            else
            {
                ApplicationBar.Buttons.RemoveAt(1);
            }
        }

        private void show_themes_bar_Click(object sender, EventArgs e)
        {
            var ids = new int[ModuleList.SelectedItems.Count];
            for (int i = 0; i < ModuleList.SelectedItems.Count; i++)
            {
                ids[i] = (ModuleList.SelectedItems[i] as Module).Id;
            }
            NavigationService.Navigate(new Uri("/View/ThemeView.xaml?type=many&str=" + String.Join(" ", ids), UriKind.Relative));
        }

        private void Testing_Click(object sender, EventArgs e)
        {
            var ids = new int[ModuleList.SelectedItems.Count];
            for (int i = 0; i < ModuleList.SelectedItems.Count; i++)
            {
                ids[i] = (ModuleList.SelectedItems[i] as Module).Id;
            }
            NavigationService.Navigate(new Uri("/View/TestingView.xaml?obj=Module&str=" + String.Join(" ", ids), UriKind.Relative));
        }

        private void select_Click(object sender, EventArgs e)
        {
            if (ModuleList.IsSelectionEnabled)
            {
                ModuleList.IsSelectionEnabled = false;
            }
            else
            {
                ModuleList.IsSelectionEnabled = true;
            }
        }
    }
}