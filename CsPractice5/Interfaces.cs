using System;

namespace CsPractice5
{
    interface ITrial
    {
        String TheTrial { get; set; }
        Boolean Result { get; set; }

        string ToString();
    }

    interface ITest : ITrial
    {
        QuestionItem[] Questions { get; set; }
        Double Mark { get; set; }
        Double MaxMark { get; set; }
    }

    interface IExam : ITest
    {
        String StudName { get; set; }
        String InfAboutStud { get; set; }
    }

    interface IFinalExam : IExam
    {
        DateTime Date { get; set; }
    }
}