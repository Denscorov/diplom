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

namespace Testing_3.View
{
    public partial class SetingsView : PhoneApplicationPage
    {
        SetingsViewModel setingsVM;
        public SetingsView()
        {
            InitializeComponent();
            setingsVM = new SetingsViewModel();
            DataContext = setingsVM;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            setingsVM.SaveSetings(address.Text, level.SelectedIndex);
            MessageBox.Show("Налашутування збережено!");
            NavigationService.Navigate(new Uri("/View/CourseView.xaml", UriKind.Relative));
        }
    }
}