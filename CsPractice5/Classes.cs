using System;

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
            if (numOfRightAns < answers.Length && numOfRightAns >= 0)
            {
                this.question = question;
                this.numOfRightAns = numOfRightAns;
                this.valueOfQuestion = valueOfQuestion;
                this.answers = answers;

                return true;
            }
            else return false;
        }

        public Boolean MakeAnswer(UInt32 numOfAnswer)
        {
            if (numOfAnswer >= 0 && numOfAnswer < answers.Length)
            {
                this.numOfAnswer = numOfAnswer;
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
        int count = 0;
        public QuestionItem[] Questions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Mark { get => mark; set => mark = value; }
        public double MaxMark { get => maxMark; set => maxMark = value; }
        public string TheTrial { get => theTrial; set => theTrial = value; }
        public bool Result { get => result; set => result = value; }

        public Test() { }

        public Test(string theTrial, int amountOfQuestions, int maxMark)
        {
            this.theTrial = theTrial;
            questions = new QuestionItem[amountOfQuestions];
            this.maxMark = maxMark;
        }

        public void InitQuestions(string question, string[] answers, uint numOfRightAns, double valueOfQuestion)
        {
            if (count < question.Length)
            {
                if (questions[count].InitQuestion(question, answers, numOfRightAns, valueOfQuestion))
                    count++;
            }
        }

        string ITrial.ToString()
        {
            return $"{theTrial}\nMark: {mark}/{maxMark} - {(result == true ? " passed" : " isn't passed")}";
        }
    }

    class Exam : IExam
    {
        string theTrial;
        bool result;
        QuestionItem[] questions;
        double mark;
        double maxMark;
        String studName;
        String infAboutStud;
        int count = 0;
        string IExam.StudName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IExam.InfAboutStud { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        QuestionItem[] ITest.Questions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        double ITest.Mark { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        double ITest.MaxMark { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string ITrial.TheTrial { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        bool ITrial.Result { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Exam() { }

        public Exam(string studName, string infAboutStud, string theTrial, double maxMark, int amountOfQuestions)
        {
            this.studName = studName;
            this.infAboutStud = infAboutStud;
            this.theTrial = theTrial;
            this.maxMark = maxMark;
            this.questions = new QuestionItem[amountOfQuestions];
        }

        public void InitQuestions(string question, string[] answers, uint numOfRightAns, double valueOfQuestion)
        {
            if (count < question.Length)
            {
                if (questions[count].InitQuestion(question, answers, numOfRightAns, valueOfQuestion))
                    count++;
            }
        }

        string ITrial.ToString()
        {
            return $"{studName}, {infAboutStud}\n{theTrial}\n{mark}/{maxMark} {(result == true ? " passed" : " isn't passed")}";
        }
    }

    class FinalExam : IFinalExam
    {
        string theTrial;
        bool result;
        QuestionItem[] questions;
        double mark;
        double maxMark;
        String studName;
        String infAboutStud;
        DateTime examDate;
        int count = 0;
        DateTime IFinalExam.Date { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IExam.StudName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IExam.InfAboutStud { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        QuestionItem[] ITest.Questions { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        double ITest.Mark { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        double ITest.MaxMark { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string ITrial.TheTrial { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        bool ITrial.Result { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public FinalExam() { }

        public FinalExam(string studName, string infAboutStud, string theTrial, double maxMark, int amountOfQuestions, DateTime examDate)
        {
            this.studName = studName;
            this.infAboutStud = infAboutStud;
            this.theTrial = theTrial;
            this.maxMark = maxMark;
            this.examDate = examDate;
            this.questions = new QuestionItem[amountOfQuestions];
        }
        public void InitQuestions(string question, string[] answers, uint numOfRightAns, double valueOfQuestion)
        {
            if (count < question.Length)
            {
                if (questions[count].InitQuestion(question, answers, numOfRightAns, valueOfQuestion))
                    count++;
            }
        }

        string ITrial.ToString()
        {
            return $"{studName}, {infAboutStud}\n{theTrial} - {examDate}\n{mark}/{maxMark} {(result == true ? " passed" : " isn't passed")}";
        }
    }
}