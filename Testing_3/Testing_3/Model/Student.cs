using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Testing_3.Model
{
    class Student
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Login { set; get; }
        public string Passwors{ set; get; }
        public bool IsActive { set; get; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Test> Tests { get; set; }
    }
}
