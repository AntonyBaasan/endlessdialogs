using System;
using System.Collections.Generic;
using System.Linq;

namespace EndlessDialogs
{
    public class Dialog : IDialog
    {
        public List<IDialog> nextDialogs;
        private int visited;
        public string text;
        public string shortText;

        public Dialog()
        {
            nextDialogs = new List<IDialog>();
        }

        public IEnumerable<IDialog> GetNext()
        {
            if(nextDialogs != null && !nextDialogs.Any())
                return null;

            return nextDialogs;
        }

        public string GetText()
        {
            return text;
        }

        public void AddNext(IDialog dialog)
        {
            if (dialog == null)
                throw new ArgumentException("Can't assign empty Dialog!");
            if (dialog == this)
                throw new ArgumentException("Can't assign self as next!");
            nextDialogs.Add(dialog);
        }

        public void AddNext(IEnumerable<IDialog> dialogs)
        {
            if(dialogs == null || !dialogs.Any())
                throw new ArgumentException("Can't assign empty Dialog list!");

            foreach (var dialog in dialogs)
            {
                AddNext(dialog);
            }
        }

        public void SetText(string text)
        {
            this.text = text;
        }

        public void Visit()
        {
            visited++;
        }

        public int VisitedAmout()
        {
            return visited;
        }

        public void SetShortText(string text)
        {
            throw new NotImplementedException();
        }

        public string GetShortText()
        {
            throw new NotImplementedException();
        }
    }
}
