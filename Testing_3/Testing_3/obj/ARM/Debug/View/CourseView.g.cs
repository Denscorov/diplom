﻿#pragma checksum "G:\Diplom\Testing_3\Testing_3\View\CourseView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9191E01CC7BF969F6278BEA27635FD6A"
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
        
        internal Microsoft.Phone.Controls.LongListMultiSelector CourseList;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton select;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton load_db;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton setings;
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem show_modules_bar;
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem show_results;
        
        internal Microsoft.Phone.Shell.ApplicationBarMenuItem auth;
        
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
            this.CourseList = ((Microsoft.Phone.Controls.LongListMultiSelector)(this.FindName("CourseList")));
            this.select = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("select")));
            this.load_db = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("load_db")));
            this.setings = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("setings")));
            this.show_modules_bar = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("show_modules_bar")));
            this.show_results = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("show_results")));
            this.auth = ((Microsoft.Phone.Shell.ApplicationBarMenuItem)(this.FindName("auth")));
        }
    }
}

