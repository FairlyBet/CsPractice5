using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsPractice5
{
    struct QuestionItem
    {
        String question;
        String[] answers;
        UInt32 numOfRightAns;
        UInt32 numOfAnswer;
        Double valueOfQuestion;
        public Double ValueOfQuestion { get => valueOfQuestion; }

        public Boolean InitQuestion(string question, string[] answers, uint numOfRightAns, double valueOfQuestion)
        {
            if (numOfRightAns < answers.Length)
            {
                this.question = question;
                this.numOfRightAns = numOfRightAns;
                this.valueOfQuestion = valueOfQuestion;
                this.answers = answers;

                return true;
            }
            else return false;
        }

        public Double CheckAns()
        {
            if (numOfAnswer == numOfRightAns)
                return valueOfQuestion;
            else return 0;
        }

        public override string ToString()
        {
            string line = "{question}:\n";
            for (int i = 0; i < answers.Length; i++)
            {
                line += $"{answers[i]}\t";
            }
            return line;
        }
    }

    class Trial : ITrial
    {
        string theTrial;
        bool result;
        public string TheTrial { get => theTrial; set => theTrial = value; }
        public bool Result { get => result; set => result = value; }

        public Trial(string theTrial = "", bool result = false)
        {
            this.theTrial = theTrial;
            this.result = result;
        }

        string ITrial.ToString()
        {
            return $"The trial: {theTrial} {(result == true ? " is done" : " isn't done")}";
        }
    }

    class Test : ITest
    { 
        string theTrial;
        bool result;
        QuestionItem[] questions;
        double mark;
        double maxMark;       
       
        public QuestionItem[] Questions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Mark { get => mark; set => mark = value; }
        public double MaxMark { get => maxMark; set => maxMark = value; }
        public string TheTrial { get => theTrial; set => theTrial = value; }
        public bool Result { get => result; set => result = value; }

        string ITrial.ToString()
        {
            return $"{theTrial}\nMark: {mark}/{maxMark} - {(result == true ? " passed" : " isn't passed")}";
        }
    }
}
