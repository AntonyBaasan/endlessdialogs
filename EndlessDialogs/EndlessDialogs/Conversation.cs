using System;
using System.Collections.Generic;
using System.Linq;

namespace EndlessDialogs
{
    public class Conversation : AbstractBasicObject, IConversation
    {

        private IEnumerable<IDialog> nextDialogs = null;
        
        public IEnumerable<IDialog> Next()
        {
            if (nextDialogs == null || !nextDialogs.Any())
                return null;
            if (nextDialogs.Count() > 1)
                throw new InvalidOperationException("Select an answer before go to next");
            //else nextDialogs.Count() == 1 //has only one next dialog
            IEnumerable<IDialog> previousDialogs = nextDialogs;
            nextDialogs = nextDialogs.First().GetNext();
            return previousDialogs;

        }

        public IEnumerable<IDialog> Answer(IDialog answer)
        {
            if(nextDialogs == null || nextDialogs.Count() <= 1)
                throw new InvalidOperationException("Not waiting for an answer");
            if (answer == null || !nextDialogs.Contains(answer))
                throw new ArgumentException("Wrong answer passed!");

            nextDialogs = answer.GetNext();
            return nextDialogs;
        }

        public void SetStartDialog(IEnumerable<IDialog> dialog)
        {
            nextDialogs = dialog;
        }

    }
}
