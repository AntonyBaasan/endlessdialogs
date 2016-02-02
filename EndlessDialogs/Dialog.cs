using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace EndlessDialogs
{

    [Serializable]
    [DataContract]
    [KnownType(typeof(Dialog))]
    public class Dialog : IDialog
    {
        [DataMember]
        public List<IDialog> nextDialogs;
        [DataMember]
        private int visited;
        [DataMember]
        private string text;
        [DataMember]
        private string shortText;
        [DataMember]
        private Speaker speaker;

        public Dialog()
        {
            nextDialogs = new List<IDialog>();
        }

        public Dialog(string text) : this()
        {
            this.text = text;
        }

        public Dialog(string text, string shortText) : this(text)
        {
            this.shortText = shortText;
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
            shortText = text;
        }

        public string GetShortText()
        {
            return shortText;
        }


        public void SetSpeaker(Speaker speaker)
        {
            this.speaker = speaker;
        }

        public Speaker GetSpeaker()
        {
            return speaker;
        }
    }
}
