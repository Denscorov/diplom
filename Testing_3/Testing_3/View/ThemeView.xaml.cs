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

        ApplicationBarIconButton testing = new ApplicationBarIconButton() { IconUri = new Uri("/Assets/AppBar/check.png", UriKind.Relative), IsEnabled = true, Text = "тестування" };
        ApplicationBarIconButton selected = new ApplicationBarIconButton() { IconUri = new Uri("/Toolkit.Content/ApplicationBar.Select.png", UriKind.Relative), IsEnabled = true, Text = "вибрати" };

        string count = "";
        string str = "";
        public ThemeView()
        {
            InitializeComponent();
            themeVM = new ThemeViewModel();
            DataContext = themeVM;

            testing.Click += testing_Click;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            NavigationContext.QueryString.TryGetValue("count", out count);
            NavigationContext.QueryString.TryGetValue("str", out str);

            if (themeVM.Entities.Count == 0)
            {
                themeVM.GetThemesByModulesId(str.Split(' ').Select(int.Parse).ToArray());
            }

            
        }

        private void testing_Click(object sender, EventArgs e)
        {
            var ids = new int[ThemeList.SelectedItems.Count];
            for (int i = 0; i < ThemeList.SelectedItems.Count; i++)
            {
                ids[i] = (ThemeList.SelectedItems[i] as Theme).Id;
            }
            NavigationService.Navigate(new Uri("/View/TestingView.xaml?type=Theme&str=" + String.Join(" ", ids), UriKind.Relative));
        }

        private void ThemeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ThemeList.SelectedItems.Count > 0)
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

        private void select_Click(object sender, EventArgs e)
        {
            if (ThemeList.IsSelectionEnabled)
            {
                ThemeList.IsSelectionEnabled = false;
            }
            else
            {
                ThemeList.IsSelectionEnabled = true;
            }
        }
    }
}