using System;
using System.Collections.Generic;
using System.Linq;

namespace EndlessDialogs
{
    public class Conversation : AbstractBasicObject, IConversation
    {
        private IEnumerable<IDialog> currentDialogs = null;
        private bool isWaitingAnswer = false;

        /// <summary>
        /// Move current state to next dialog
        /// </summary>
        public void Next()
        {
            if (isWaitingAnswer)
                throw new InvalidOperationException("Select an answer before go to next");

            foreach (var previousDialog in currentDialogs)
                previousDialog.Visit();

            currentDialogs = currentDialogs.First().GetNext();
            if(currentDialogs == null)
                currentDialogs = new IDialog[0]; 

            isWaitingAnswer = currentDialogs.Count() > 1;
        }

        public IEnumerable<IDialog> CurrentDialogs()
        {
            if (currentDialogs == null || !currentDialogs.Any())
                return new IDialog[0];

            return currentDialogs;
        }

        public void Answer(IDialog answer)
        {
            if (!isWaitingAnswer)
                throw new InvalidOperationException("Not waiting for an answer");
            if (answer == null || !currentDialogs.Contains(answer))
                throw new ArgumentException("Wrong answer passed!");

            isWaitingAnswer = false;
            currentDialogs = new[] { answer };
            Next();
        }

        public void SetStartDialog(IEnumerable<IDialog> dialog)
        {
            currentDialogs = dialog;

            isWaitingAnswer = currentDialogs.Count() > 1;

        }

        public bool IsWaitingAnswer()
        {
            return isWaitingAnswer;
        }
    }
}
