using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Testing_OKM_2.Model
{
    [Table("Theme")]
    class Theme
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        [Column("Name"), NotNull]
        public string Name { set; get; }

        [ForeignKey(typeof(Module))]
        public int ModuleId { set; get; }

        [ManyToOne]
        public Module Module { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Question> Questions { set; get; }

        public Theme(){}

        public Theme(string name)
        {
            Name = name;
        }
    }
}
