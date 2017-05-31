using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.CompilerServices;
using Testing_3.Model;

namespace Testing_3.VIewModel
{
    class SetingsViewModel : INotifyPropertyChanged
    {
        SQLite.Net.SQLiteConnection database;

        Setings setings;
        public Setings Setings
        {
            get
            {
                return setings;
            }
            set
            {
                setings = value;
                App.IP_ADDRESS = setings.Ip_address;
                App.Level = setings.Level;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public SetingsViewModel()
        {
            database = DBConnection.GetCoonection();

            if (database.Table<Setings>().Count() < 1)
            {
                database.Insert(new Setings("http://192.168.0.101", 0));
            }
            else
            {
                Setings = database.Table<Setings>().First();
            }
        }

        public void SaveSetings(string ip_address, int level)
        {
            Setings.Ip_address = ip_address;
            Setings.Level = level;
            database.Update(setings);
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
