namespace EndlessDialogs
{
    public interface IDialog
    {
        void SetText(string text);

        string GetText();

        IDialog[] GetNext();

        void SetNext(IDialog nextDialogs);

        void SetNext(IDialog[] nextDialogs);

        void Visit();

        int VisitedAmout();
    }
}
