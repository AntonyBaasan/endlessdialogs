using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessDialogs
{
    public class Conversation : IConversation
    {
        public void AddDialog(IDialog[] dialog)
        {
            throw new NotImplementedException();
        }

        public void AddDialog(IDialog dialog)
        {
            throw new NotImplementedException();
        }

        public IDialog[] GetAllDialogs()
        {
            throw new NotImplementedException();
        }

        public string GetDescription()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public IDialog Next()
        {
            throw new NotImplementedException();
        }

        public IDialog Next(IDialog answer)
        {
            throw new NotImplementedException();
        }

        public void RemoveDialog(IDialog dialog)
        {
            throw new NotImplementedException();
        }

        public void SetDescription(string description)
        {
            throw new NotImplementedException();
        }

        public void SetName(string name)
        {
            throw new NotImplementedException();
        }

        public void SetStartDialog(IDialog dialog)
        {
            throw new NotImplementedException();
        }
    }
}
