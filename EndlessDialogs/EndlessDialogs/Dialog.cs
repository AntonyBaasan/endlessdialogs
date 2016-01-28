using System;

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
