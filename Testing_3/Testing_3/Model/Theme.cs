using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Testing_3.Model
{
    class Theme
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        public string Name { set; get; }

        [ForeignKey(typeof(Module))]
        public int ModuleId { set; get; }

        [ManyToOne]
        public Module Module { get; set; }
    }
}
