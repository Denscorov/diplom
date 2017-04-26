using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Testing_3.Model
{
    class Course
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        public string Name { set; get; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Module> Modules { get; set; }
    }
}
