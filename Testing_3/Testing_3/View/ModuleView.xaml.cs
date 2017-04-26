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
    public partial class ModuleView : PhoneApplicationPage
    {
        ModuleViewModel moduleVM;
        string type = "";
        string str = "";
        public ModuleView()
        {
            InitializeComponent();
            moduleVM = new ModuleViewModel();
            DataContext = moduleVM;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ModuleList.SelectedIndex = -1;
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

        private void select_all_Click(object sender, EventArgs e)
        {
            ModuleList.SelectAll();
        }

        private void unselect_Click(object sender, EventArgs e)
        {
            ModuleList.SelectedIndex = -1;
        }

        private void ModuleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ModuleList.SelectedItems.Count > 0)
            {
                (ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled = true;
            }
            else
            {
                (ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled = false;
            }
        }

        private void show_themes_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            var module = item.DataContext as Module;
            NavigationService.Navigate(new Uri("/View/ThemeView.xaml?type=one&str=" + module.Id, UriKind.Relative));
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
    }
}