using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using Testing_3.Model;

namespace Testing_3.Model
{
    class Module
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        public string Name { set; get; }

        [ForeignKey(typeof(Course))]
        public int CourseId { set; get; }

        [ManyToOne]
        public Course Course { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Theme> Themes { get; set; }
    }
}
