using System.Collections.Generic;

namespace EndlessDialogs
{
    public interface IConversation : IBasicObject
    {
        void SetStartDialog(IEnumerable<IDialog> dialog);

        IEnumerable<IDialog> Next();

        IEnumerable<IDialog> Answer(IDialog answer);

    }
}
