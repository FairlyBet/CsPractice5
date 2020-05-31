namespace CsPractice5
{
    interface ITrial
    {
        string TheTrial { get; }
        bool Result { get; }

        void Edit(string theTrial, bool result);
    }

    interface ITest : ITrial
    {
        float Mark { get; }
        float MaxMark { get; }

        void Edit(string theTrial, bool result, float mark, float maxMark);
    }
}