using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using Test_1.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLiteNetExtensions.Extensions;

namespace Test_1
{
    class DataAccess : INotifyPropertyChanged
    {
        SQLiteConnection dataBase;

        public event PropertyChangedEventHandler PropertyChanged;

        ObservableCollection<User> users;
        ObservableCollection<Book> books;

        public ObservableCollection<User> Users
        {
            get
            {
                return users;
            }
            set
            {
                if (value != users)
                {
                    users = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DataAccess()
        {
            dataBase = DBConnection.GetCoonection();
            GetAllUsers();
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void GetAllUsers()
        {
            Users = new ObservableCollection<User>(dataBase.GetAllWithChildren<User>());
        }

        public void InsertUser(User user)
        {
            dataBase.Insert(user);
            GetAllUsers();
        }

        public void DeleteUser(User user)
        {
            dataBase.Delete(user);
            GetAllUsers();
        }

        public void AddBookToUser(User user, params Book[] books)
        {
            if (user.Books == null)
            {
                user.Books = new List<Book>();
            }
            foreach (var book in books)
            {
                dataBase.Insert(book);
                user.Books.Add(book);
            }
            dataBase.UpdateWithChildren(user);
            GetAllUsers();
        }

        public void AddFriend(User user, List<User> friends)
        {
            user.FriendUser.AddRange(friends);
            dataBase.UpdateWithChildren(user);
            GetAllUsers();
            var f = dataBase.Table<UserFriends>().ToList();
        }
    }
}
