using System;
using System.Collections.Generic;
using System.Linq;

namespace EndlessDialogs
{
    public class Conversation : AbstractBasicObject, IConversation
    {

        private IEnumerable<IDialog> nextDialogs = null;
        private bool waitingAnswer = false;
        
        public IEnumerable<IDialog> Next()
        {
            if (nextDialogs == null || !nextDialogs.Any())
                return null;
            if (waitingAnswer)
                throw new InvalidOperationException("Select an answer before go to next");

            IEnumerable<IDialog> previousDialogs = nextDialogs;
            foreach (var previousDialog in previousDialogs)
                previousDialog.Visit();

            if (nextDialogs.Count() == 1)
                nextDialogs = nextDialogs.First().GetNext();
            else
                waitingAnswer = true;
            
            return previousDialogs;

        }

        public void Answer(IDialog answer)
        {
            if(!waitingAnswer)
                throw new InvalidOperationException("Not waiting for an answer");
            if (answer == null || !nextDialogs.Contains(answer))
                throw new ArgumentException("Wrong answer passed!");

            waitingAnswer = false;
            nextDialogs = answer.GetNext();
        }

        public void SetStartDialog(IEnumerable<IDialog> dialog)
        {
            nextDialogs = dialog;
        }

    }
}
