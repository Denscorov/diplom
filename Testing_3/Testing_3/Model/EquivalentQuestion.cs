using SQLiteNetExtensions.Attributes;

namespace Testing_3.Model
{
    class EquivalentQuestion
    {
        [ForeignKey(typeof(Question))]
        public int QuestionId { get; set; }

        [ForeignKey(typeof(Question))]
        public int EquivalentQuestionId { get; set; }
    }
}
