using System.Collections.Generic;

namespace EndlessDialogs
{
    public interface IConversation : IBasicObject
    {
        void SetStartDialog(IEnumerable<IDialog> dialog);

        IEnumerable<IDialog> Next();

        void Answer(IDialog answer);

    }
}
