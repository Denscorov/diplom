using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Testing_3.Model
{
    class Question
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        public string Text { set; get; }
        public int Type { set; get; }
        public int Level { set; get; }

        [ForeignKey(typeof(Theme))]
        public int ThemeId { set; get; }

        [ManyToOne]
        public Theme Theme{ get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Answer> Answers { get; set; }

        [ManyToMany(typeof(EquivalentQuestion), "QuestionId", "myEquivalent", CascadeOperations = CascadeOperation.All)]
        public List<Question> EquilentParent { get; set; }
        [ManyToMany(typeof(EquivalentQuestion), "myEquivalentId", "EquilentParent", CascadeOperations = CascadeOperation.All)]
        public List<Question> myEquivalent { get; set; }
    }
}
