using SQLiteNetExtensions.Attributes;
using SQLite.Net.Attributes;
using System.Collections.Generic;

namespace Testing_OKM.Model
{
    [Table("Module")]
    class Module
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        [Column("Name"), NotNull]
        public string Name { set; get; }

        [ForeignKey(typeof(Course))]
        public int CourseId { set; get; }

        [ManyToOne]
        public Course Course { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Theme> Themes { set; get; }

        public Module(){}

        public Module(string name)
        {
            Name = name;
            Themes = new List<Theme>();
        }
    }
}
