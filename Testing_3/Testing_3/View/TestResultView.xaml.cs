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
    public partial class TestResultView : PhoneApplicationPage
    {
        TestViewModel testVm;

        public TestResultView()
        {
            InitializeComponent();
            testVm = new TestViewModel();
            testVm.GetAllTests();
            DataContext = testVm;
        }

        private void select_Click(object sender, EventArgs e)
        {
            if (TestResultList.IsSelectionEnabled)
            {
                TestResultList.IsSelectionEnabled = false;
            }
            else
            {
                TestResultList.IsSelectionEnabled = true;
            }
        }

        private void sort_by_type_Click(object sender, EventArgs e)
        {
            testVm.SortBytype();
        }

        private void sort_by_date_Click(object sender, EventArgs e)
        {
            testVm.SortByDate();
        }
    }
}