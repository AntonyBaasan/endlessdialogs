using System;
using System.Collections.Generic;

namespace EndlessDialogs
{
    public class Dialog : IDialog
    {
        
        public IEnumerable<IDialog> GetNext()
        {
            throw new NotImplementedException();
        }

        public string GetText()
        {
            throw new NotImplementedException();
        }

        public void AddNext(IDialog nextDialogs)
        {
            throw new NotImplementedException();
        }

        public void AddNext(IEnumerable<IDialog> nextDialogs)
        {
            throw new NotImplementedException();
        }

        public void SetText(string text)
        {
            throw new NotImplementedException();
        }

        public void Visit()
        {
            throw new NotImplementedException();
        }

        public int VisitedAmout()
        {
            throw new NotImplementedException();
        }
    }
}
