using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Testing_3.Model;
using Testing_3.VIewModel;

namespace Testing_3.View
{
    public partial class ThemeView : PhoneApplicationPage
    {
        ThemeViewModel themeVM;
        string type = "";
        string str = "";
        public ThemeView()
        {
            InitializeComponent();
            themeVM = new ThemeViewModel();
            DataContext = themeVM;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ThemeList.SelectedIndex = -1;
            base.OnNavigatedTo(e);
            NavigationContext.QueryString.TryGetValue("type", out type);
            NavigationContext.QueryString.TryGetValue("str", out str);
            if (type == "many")
            {
                themeVM.GetThemesByModulesId(str.Split(' ').Select(int.Parse).ToArray());
            }
            else
            {
                themeVM.GetThemesByModuleId(int.Parse(str));
            }
        }

        private void select_all_Click(object sender, EventArgs e)
        {
            ThemeList.SelectAll();
        }

        private void unselect_Click(object sender, EventArgs e)
        {
            ThemeList.SelectedIndex = -1;
        }

        private void start_testing_Click(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            var theme = item.DataContext as Theme;
            NavigationService.Navigate(new Uri("/View/TestingView.xaml?obj=Theme&str=" + theme.Id, UriKind.Relative));
        }

        private void testing_Click(object sender, EventArgs e)
        {
            var ids = new int[ThemeList.SelectedItems.Count];
            for (int i = 0; i < ThemeList.SelectedItems.Count; i++)
            {
                ids[i] = (ThemeList.SelectedItems[i] as Theme).Id;
            }
            NavigationService.Navigate(new Uri("/View/TestingView.xaml?obj=Theme&str=" + String.Join(" ", ids), UriKind.Relative));
        }

        private void ThemeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ThemeList.SelectedItems.Count > 0)
            {
                (ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled = true;
            }
            else
            {
                (ApplicationBar.Buttons[0] as ApplicationBarIconButton).IsEnabled = false;
            }
        }
    }
}