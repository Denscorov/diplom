using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Testing_2
{
    class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        public string Name{ set; get; }

        public User() { }

        public User(string name)
        {
            Name = name;
        }
    }
}
