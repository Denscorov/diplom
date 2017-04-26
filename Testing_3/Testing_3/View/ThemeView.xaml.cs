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
    }
}