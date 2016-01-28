using System;
using System.Collections.Generic;
using System.Linq;

namespace EndlessDialogs
{
    public class Conversation : IConversation
    {
        private string Name;
        private string Description;

        private IEnumerable<IDialog> nextDialogs = null;
        
        public string GetDescription()
        {
            return Description;
        }

        public string GetName()
        {
            return Name;
        }
        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetName(string name)
        {
            Name = name;
        }


        public IEnumerable<IDialog> Next()
        {
            if (nextDialogs == null || !nextDialogs.Any())
                return null;
            if (nextDialogs.Count() > 1)
                throw new InvalidOperationException("Answer before go");
            //else nextDialogs.Count() == 1 //has only one next dialog
            IEnumerable<IDialog> previousDialogs = nextDialogs;
            nextDialogs = nextDialogs.First().GetNext();
            return previousDialogs;
        }

        public IEnumerable<IDialog> Answer(IDialog answer)
        {
            throw new NotImplementedException();
        }

        public void SetStartDialog(IEnumerable<IDialog> dialog)
        {
            nextDialogs = dialog;
        }
    }
}
