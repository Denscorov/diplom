﻿#pragma checksum "G:\Diplom\Testing_3\Testing_3\View\TestingView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EC27822985DB11BE9634ACF3C9660A1E"
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
    
    
    public partial class TestingView : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Documents.Run QuestionNumber;
        
        internal System.Windows.Documents.Run TrueQuestionNumber;
        
        internal System.Windows.Controls.TextBlock questionText;
        
        internal System.Windows.Controls.ListBox questionAnswers;
        
        internal System.Windows.Controls.TextBox TextAnswer;
        
        internal System.Windows.Controls.Button NextQuestion;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Testing_3;component/View/TestingView.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.QuestionNumber = ((System.Windows.Documents.Run)(this.FindName("QuestionNumber")));
            this.TrueQuestionNumber = ((System.Windows.Documents.Run)(this.FindName("TrueQuestionNumber")));
            this.questionText = ((System.Windows.Controls.TextBlock)(this.FindName("questionText")));
            this.questionAnswers = ((System.Windows.Controls.ListBox)(this.FindName("questionAnswers")));
            this.TextAnswer = ((System.Windows.Controls.TextBox)(this.FindName("TextAnswer")));
            this.NextQuestion = ((System.Windows.Controls.Button)(this.FindName("NextQuestion")));
        }
    }
}

