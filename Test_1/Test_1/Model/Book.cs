using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Test_1.Model
{
    class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        public string Name { set; get; }

        [ForeignKey(typeof(User))]
        public int UserId { set; get; }

        [ManyToOne(CascadeOperations = CascadeOperation.All)]
        public User user { get; set; }

        public Book() { }

        public Book(string name)
        {
            Name = name;
        }
    }
}
