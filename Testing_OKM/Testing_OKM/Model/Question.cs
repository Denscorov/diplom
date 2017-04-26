using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Testing_OKM.Model
{
    [Table("Question")]
    class Question
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        [Column("QuestionText"), NotNull]
        public string QuestionText { set; get; }
        [Column("Type"), NotNull]
        public int Type { set; get; }
        [Column("Level"), NotNull]
        public int Level { set; get; }

        [ForeignKey(typeof(Theme))]
        public int ThemeId { set; get; }

        [ManyToOne]
        public Theme Theme { set; get; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Answer> Answers { set; get; }

        [ManyToMany(typeof(EquivalentQuestion), "EquivalentQuestionId", null, CascadeOperations = CascadeOperation.All, ReadOnly = false)]
        public List<Question> EquivalentQuestion { set; get; }

        public Question(){}

        public Question(string questionText, int type, int level)
        {
            QuestionText = questionText;
            Type = type;
            Level = level;
            Answers = new List<Answer>();
            EquivalentQuestion = new List<Question>();
        }


    }
}
