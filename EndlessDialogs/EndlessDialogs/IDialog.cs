using System.Collections.Generic;

namespace EndlessDialogs
{
    public interface IDialog
    {
        void SetText(string text);

        string GetText();

        void SetShortText(string text);

        string GetShortText();

        IEnumerable<IDialog> GetNext();

        void AddNext(IDialog nextDialogs);

        void AddNext(IEnumerable<IDialog> nextDialogs);

        void Visit();

        int VisitedAmout();
    }
}
