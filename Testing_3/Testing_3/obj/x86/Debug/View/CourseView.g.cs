﻿#pragma checksum "G:\Diplom\Testing_3\Testing_3\View\CourseView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "135BC59298A784ADC23F784A750AE6EC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Testing_3.View {
    
    
    public partial class CourseView : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.ListBox CourseList;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton Testing;
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem show_modules_bar;
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem select_all;
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem unselect;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Testing_3;component/View/CourseView.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.CourseList = ((System.Windows.Controls.ListBox)(this.FindName("CourseList")));
            this.Testing = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("Testing")));
            this.show_modules_bar = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("show_modules_bar")));
            this.select_all = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("select_all")));
            this.unselect = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("unselect")));
        }
    }
}

