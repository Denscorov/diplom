using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using Newtonsoft.Json;

namespace Testing_3.Model
{
    class Test
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        public string Type { set; get; }
        public string Description { set; get; }
        public int QCount { set; get; }
        public int QTCount { set; get; }
        public string Date { set; get; }
        public string Time { set; get; }
        public string Timer { set; get; }

        [ForeignKey(typeof(Student))]
        public int StudentId { set; get; }

        [ManyToOne]
        public Student Student { get; set; }

        public Test() { }
        public Test(string type, string description, int qCount, int qtCount, string time, string date, string timer, Student st)
        {
            Type = type;
            Description = description;
            QCount = qCount;
            QTCount = qtCount;
            Time = time;
            Date = date;
            Timer = timer;
            Student = st;
        }
    }
}
