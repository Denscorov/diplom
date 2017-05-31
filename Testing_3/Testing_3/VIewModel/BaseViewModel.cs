using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Testing_3.VIewModel
{
    /// <summary>
    /// Базовий клас для класів групи ViewModel
    /// </summary>
    /// <typeparam name="T"></typeparam>
    abstract class BaseViewModel<T> : INotifyPropertyChanged
    {
        public BaseViewModel(){}
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
                entities = value;
                NotifyPropertyChanged("Entities");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        static Random rng = new Random();
        public static void Shuffle(IList<T> list)
        {
            int n = list.Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
