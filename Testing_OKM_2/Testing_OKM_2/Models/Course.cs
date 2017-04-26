using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Testing_OKM_2.Model
{
    [Table("Course")]
    class Course
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        [Column("Name"), NotNull]
        public string Name { set; get; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Module> Modules { get; set; }

        public Course(){}

        public Course(string name)
        {
            Name = name;
            Modules = new List<Module>();
        }
    }
}
