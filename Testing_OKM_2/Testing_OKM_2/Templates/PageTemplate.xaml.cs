using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace Testing_OKM_2.Templates
{
    public partial class PageTemplate : UserControl
    {
        public PageTemplate()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public static readonly DependencyProperty HeaderTitleProperty = DependencyProperty.Register("HeaderTitle", typeof(string), typeof(PageTemplate), new PropertyMetadata(null));

        public string HeaderTitle
        {
            get { return (string)GetValue(HeaderTitleProperty); }
            set { SetValue(HeaderTitleProperty, value); }
        }

        public static readonly DependencyProperty HeaderTextProperty = DependencyProperty.Register("HeaderText", typeof(string), typeof(PageTemplate), new PropertyMetadata(null));

        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }

        public static readonly DependencyProperty MainProperty = DependencyProperty.Register("Main", typeof(object), typeof(PageTemplate), new PropertyMetadata(null));

        public object Main
        {
            get { return GetValue(MainProperty); }
            set { SetValue(MainProperty, value); }
        }

        public static readonly DependencyProperty FooterTextProperty = DependencyProperty.Register("FooterText", typeof(object), typeof(PageTemplate), new PropertyMetadata(null));

        public object FooterText
        {
            get { return GetValue(FooterTextProperty); }
            set { SetValue(FooterTextProperty, value); }
        }
    }
}
