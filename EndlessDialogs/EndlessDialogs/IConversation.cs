using System.Collections.Generic;

namespace EndlessDialogs
{
    public interface IConversation
    {
        void SetStartDialog(IEnumerable<IDialog> dialog);

        void SetName(string name);

        string GetName();

        void SetDescription(string description);

        string GetDescription();

        IEnumerable<IDialog> Next();

        IEnumerable<IDialog> Answer(IDialog answer);

    }
}
