using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Testing_2
{
    public partial class PageTemplate : UserControl
    {
        public PageTemplate()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("HeaderBlock", typeof(object), typeof(PageTemplate), new PropertyMetadata(null));

        public object HeaderBlock
        {
            get { return GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty MainBlockProperty = DependencyProperty.Register("MainBlock", typeof(object), typeof(PageTemplate), new PropertyMetadata(null));

        public object MainBlock
        {
            get { return GetValue(MainBlockProperty); }
            set { SetValue(MainBlockProperty, value); }
        }

        public static readonly DependencyProperty FooterBlockProperty = DependencyProperty.Register("FooterBlock", typeof(object), typeof(PageTemplate), new PropertyMetadata(null));

        public object FooterBlock
        {
            get { return GetValue(FooterBlockProperty); }
            set { SetValue(FooterBlockProperty, value); }
        }

    }
}
