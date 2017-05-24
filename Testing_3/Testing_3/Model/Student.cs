using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using Newtonsoft.Json;

namespace Testing_3.Model
{
    class Student
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Login { set; get; }
        public string Password{ set; get; }
        public bool Is_Active { set; get; }

        [OneToMany(CascadeOperations = CascadeOperation.All), JsonIgnore]
        public List<Test> Tests { get; set; }
    }
}
