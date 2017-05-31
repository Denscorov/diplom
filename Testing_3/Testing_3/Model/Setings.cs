using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Testing_3.Model
{
    [Table("setings")]
    class Setings
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Ip_address { set; get; }
        public int Level { get; set; } 

        public Setings() { }

        public Setings(string ip, int level)
        {
            Ip_address = ip; Level = level;
        }
    }
}
