using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessDialogs
{
    public class Dialog : IDialog
    {
        public IDialog[] GetNext()
        {
            throw new NotImplementedException();
        }

        public string GetText()
        {
            throw new NotImplementedException();
        }

        public void SetNext(IDialog nextDialogs)
        {
            throw new NotImplementedException();
        }

        public void SetNext(IDialog[] nextDialogs)
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
