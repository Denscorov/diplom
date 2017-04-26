using SQLite.Net;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Testing_3.VIewModel
{
    abstract class BaseViewModel<T> : INotifyPropertyChanged
    {
        protected SQLiteConnection database;
        ObservableCollection<T> entities;
        public ObservableCollection<T> Entities
        {
            get
            {
                return entities;
            }
            set
            {
                if (value != entities)
                {
                    entities = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
