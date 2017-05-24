using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Testing_3.CompareString;
using Testing_3.Model;

namespace Testing_3
{
    class QuestionNotify : INotifyPropertyChanged
    {
        int trueQuestion = 0;
        public int TrueQuestion
        {
            set
            {
                trueQuestion = value;
                NotifyPropertyChanged();
            }
            get
            {
                return trueQuestion;
            }
        }

        int numberQuestion = 0;
        public int NumberQuestion
        {
            set
            {
                numberQuestion = value;
                NotifyPropertyChanged();
            }
            get
            {
                return numberQuestion;
            }
        }

        int index = 0;

        Question[] questions;

        Question curentQuestion;

        TimeSpan timer;

        public TimeSpan Timer
        {
            set
            {
                timer = value;
            }
            get
            {
                return timer;
            }
        }

        public Question CurentQuestion
        {
            set
            {
                if (!EquivalentQuestion.Contains(value))
                {
                    curentQuestion = value;
                    EquivalentQuestion.AddRange(CurentQuestion.myEquivalent);
                    NotifyPropertyChanged();
                }
                else
                {
                    SkipQuestion();
                }
            }
            get
            {
                return curentQuestion;
            }
        }

        List<Question> EquivalentQuestion;

        public QuestionNotify(Question[] questions)
        {
            EquivalentQuestion = new List<Question>();
            this.questions = questions;
            CurentQuestion = questions[index];
            NumberQuestion++;
            index++;
            timer = new TimeSpan(0,0,0);
        }

        public bool NextQuestion(string textAnswer)
        {
            if (CurentQuestion.Answers.Count > 0)
            {
                var i = ScoreSharp.score(CurentQuestion.Answers[0].Text, textAnswer);
                if (i > 0.7)
                {
                    TrueQuestion++;
                }
            }

            if (index++ < questions.Count() - 1)
            {
                CurentQuestion = questions[index++];
                NumberQuestion++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NextQuestion(Answer answer)
        {
            foreach (var ans in CurentQuestion.Answers)
            {
                if (ans.Corect && ans.Id == answer.Id)
                {
                    TrueQuestion++;
                }
            }

            if (NumberQuestion < questions.Count() - 1)
            {
                CurentQuestion = questions[index++];
                NumberQuestion++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NextQuestion(Answer[] answers)
        {
            var x = CurentQuestion.Answers.Where(a => a.Corect == true).Select(a => a.Id).ToArray();
            var y = answers.Select(a => a.Id).ToArray();
            if (x.SequenceEqual(y))
            {
                TrueQuestion++;
            }

            if (NumberQuestion < questions.Count() - 1)
            {
                CurentQuestion = questions[index++];
                NumberQuestion++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SkipQuestion()
        {
            CurentQuestion = questions[index++];
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TimeSpan AddTimer(TimeSpan time)
        {
            return Timer += time;
        }
    }
}
