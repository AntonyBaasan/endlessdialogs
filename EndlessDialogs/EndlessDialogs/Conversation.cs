using System;
using System.Collections.Generic;
using System.Linq;

namespace EndlessDialogs
{
    public class Conversation : AbstractBasicObject, IConversation
    {

        private IEnumerable<IDialog> nextDialogs = null;
        private bool isWaitingAnswer = false;
        
        public IEnumerable<IDialog> Next()
        {
            if (nextDialogs == null || !nextDialogs.Any())
                return null;
            if (isWaitingAnswer)
                throw new InvalidOperationException("Select an answer before go to next");

            IEnumerable<IDialog> previousDialogs = nextDialogs;
            foreach (var previousDialog in previousDialogs)
                previousDialog.Visit();

            if (nextDialogs.Count() == 1)
                nextDialogs = nextDialogs.First().GetNext();
            else
                isWaitingAnswer = true;
            
            return previousDialogs;

        }

        public void Answer(IDialog answer)
        {
            if(!isWaitingAnswer)
                throw new InvalidOperationException("Not waiting for an answer");
            if (answer == null || !nextDialogs.Contains(answer))
                throw new ArgumentException("Wrong answer passed!");

            isWaitingAnswer = false;
            nextDialogs = answer.GetNext();
        }

        public void SetStartDialog(IEnumerable<IDialog> dialog)
        {
            nextDialogs = dialog;
        }

        public bool IsWaitingAnswer()
        {
            return isWaitingAnswer;
        }
    }
}
