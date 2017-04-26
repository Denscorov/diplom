using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Testing_3.Model
{
    class Answer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        public string Text { set; get; }
        public bool Corect { set; get; }

        [ForeignKey(typeof(Question))]
        public int QuestionId { set; get; }

        [ManyToOne]
        public Question Question { get; set; }
    }
}
