using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessDialogs
{
    public interface IConversation
    {
        void SetStartDialog(IDialog dialog);

        void AddDialog(IDialog dialog);

        void RemoveDialog(IDialog dialog);

        IDialog[] GetAllDialogs();

        void SetName(string name);

        string GetName();

        void SetDescription(string description);

        string GetDescription();

        IDialog Next();

        IDialog Next(IDialog answer);

    }
}
