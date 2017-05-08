using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Testing_3.Model
{
    class Test
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }

        public string Type { set; get; }
        public string Ids { set; get; }
        public int QCount { set; get; }
        public int QTCount { set; get; }
        public DateTime DTime { set; get; }

        public Test() { }
        public Test(string type, string ids, int qCount, int qtCount, DateTime dTime)
        {
            Type = type;
            Ids = ids;
            QCount = qCount;
            QTCount = qtCount;
            DTime = dTime;
        }
    }
}
