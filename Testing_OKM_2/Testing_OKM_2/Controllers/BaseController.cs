using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Extensions;
using Testing_OKM_2.Model;

namespace Testing_OKM_2.Controllers
{
    abstract class BaseController<T> : INotifyPropertyChanged
    {
        string headerTitle;
        public string HeaderTitle
        {
            get
            {
                return headerTitle;
            }
            set
            {
                if (value != headerTitle)
                {
                    headerTitle = value;
                    NotifyPropertyChanged();
                }
            }
        }
        string headerText;
        public string HeaderText
        {
            get
            {
                return headerText;
            }
            set
            {
                if (value != headerText)
                {
                    headerText = value;
                    NotifyPropertyChanged();
                }
            }
        }
        string footerText;
        public string FooterText
        {
            get
            {
                return footerText;
            }
            set
            {
                if (value != footerText)
                {
                    footerText = value;
                    NotifyPropertyChanged();
                }
            }
        }
        protected SQLiteConnection database;
        protected static object collisionLock = new object();
        ObservableCollection<T> entity;
        public ObservableCollection<T> Entity
        {
            get
            {
                return entity;
            }
            set
            {
                if (value != entity)
                {
                    entity = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected BaseController() {
            database = DBConnection.GetCoonection();
            HeaderTitle = "Тестування ОКМ";
        }

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
