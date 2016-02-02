using System.Collections.Generic;

namespace EndlessDialogs
{
    public interface IConversation : IBasicObject
    {
        void SetStartDialog(IEnumerable<IDialog> dialog);

        void Next();

        IEnumerable<IDialog> CurrentDialogs();

        void Answer(IDialog answer);

        bool IsWaitingAnswer();

    }
}
