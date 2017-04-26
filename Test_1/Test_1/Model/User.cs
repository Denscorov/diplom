using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Test_1.Model
{
    [Table("user")]
    class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        public string Name { set; get; }

        [OneToMany]
        public List<Book> Books { set; get; }

        [ManyToMany(typeof(UserFriends), "UserId", "Friends", CascadeOperations = CascadeOperation.All)]
        public List<User> FriendUser { set; get; }

        [ManyToMany(typeof(UserFriends), "FriendId", "FriendUser", CascadeOperations = CascadeOperation.All, ReadOnly = true)]
        public List<User> Friends { set; get; }

        public User() { }

        public User (string name)
        {
            Name = name;
            Books = new List<Book>();
            FriendUser = new List<User>();
            Friends = new List<User>();
        }

    }
}
