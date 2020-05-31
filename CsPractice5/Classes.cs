using System;

namespace CsPractice5
{
    class Trial : ITrial
    {
        string theTrial;
        bool result;
        public string TheTrial { get => theTrial; set => theTrial = value; }
        public bool Result { get => result; set => result = value; }

        public Trial() { }

        public Trial(string theTrial, bool result)
        {
            this.theTrial = theTrial;
            this.result = result;
        }

        public void Edit(string theTrial, bool result)
        {
            this.theTrial = theTrial;
            this.result = result;
        }

        public override string ToString()
        {
            return $"{theTrial} {(result == true ? "is completed" : "isn't completed")}";
        }
    }

    class Test : Trial, ITest
    {
        float mark;
        float maxMark;
        public float Mark { get => mark; set => mark = value; }
        public float MaxMark { get => maxMark; set => maxMark = value; }

        public Test() { }

        public Test(string theTrial, bool result, float mark, float maxMark)
        {
            base.TheTrial = theTrial;
            base.Result = result;
            this.mark = mark;
            this.maxMark = maxMark;
        }

        public void Edit(string theTrial, bool result, float mark, float maxMark)
        {
            base.Edit(theTrial, result);
            this.mark = mark;
            this.maxMark = maxMark;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n{mark}/{maxMark}";
        }
    }

    class Exam : Test
    {
        string fullInformation;
        public string FullInformation { get => fullInformation; set => fullInformation = value; }

        public Exam() { }

        public Exam(string theTrial, bool result, float mark, float maxMark, string fullInformation)
        {
            base.TheTrial = theTrial;
            base.Result = result;
            base.Mark = mark;
            base.MaxMark = maxMark;
            this.fullInformation = fullInformation;
        }

        public void Edit(string theTrial, bool result, float mark, float maxMark, string fullInformation)
        {
            this.fullInformation = fullInformation;
            base.Edit(theTrial, result, mark, maxMark);
        }

        public override string ToString()
        {
            return $"{fullInformation}\n{base.ToString()}";
        }
    }

    class FinalExam : Exam
    {
        DateTime examDate;
        public DateTime ExamDate { get => examDate; }

        public FinalExam() { }

        public FinalExam(string theTrial, bool result, float mark, float maxMark, string fullInformation, DateTime examDate)
        {
            base.TheTrial = theTrial;
            base.Result = result;
            base.Mark = mark;
            base.MaxMark = maxMark;
            base.FullInformation = fullInformation;
            this.examDate = examDate;
        }

        public void Edit(string theTrial, bool result, float mark, float maxMark, string fullInformation, DateTime examDate)
        {
            this.examDate = examDate;
            base.Edit(theTrial, result, mark, maxMark, fullInformation);
        }

        public override string ToString()
        {
            return $"{examDate}\n{base.ToString()}";
        }
    }
}