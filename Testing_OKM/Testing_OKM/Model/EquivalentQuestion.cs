using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace Testing_OKM.Model
{
    [Table("EquivalentQuestion")]
    class EquivalentQuestion
    {
        [ForeignKey(typeof(Question))]
        public int QuestionId { get; set; }

        [ForeignKey(typeof(Question))]
        public int EquivalentQuestionId { get; set; }
    }
}
