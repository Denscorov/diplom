using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Testing_OKM_2.Model
{
    [Table("Answer")]
    class Answer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        [Column("AnswerText"), NotNull]
        public string AnswerText { set; get; }
        [Column("Correct"), NotNull]
        public bool Correct { set; get; }

        [ForeignKey(typeof(Question))]
        public int QuestionId { set; get; }

        [ManyToOne]
        public Question Question { set; get; }

        public Answer(){}
        
        public Answer (string answerText, bool correct)
        {
            AnswerText = answerText;
            Correct = correct;
        }
    }
}
