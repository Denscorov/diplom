using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using Newtonsoft.Json;

namespace Testing_3.Model
{
    class Test
    {
        [PrimaryKey, AutoIncrement, JsonIgnore]
        public int Id { set; get; }
        [JsonProperty("type")]
        public string Type { set; get; }
        [JsonProperty("description")]
        public string Description { set; get; }
        [JsonProperty("q_count")]
        public int QCount { set; get; }
        [JsonProperty("q_t_count")]
        public int QTCount { set; get; }
        [JsonProperty("date")]
        public string Date { set; get; }
        [JsonProperty("time")]
        public string Time { set; get; }
        [JsonProperty("timer")]
        public string Timer { set; get; }

        [JsonIgnore]
        public bool Load { set; get; }

        [ForeignKey(typeof(Student)), JsonProperty("student")]
        public int StudentId { set; get; }

        [ManyToOne, JsonIgnore]
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
            Load = false;
        }
    }
}
