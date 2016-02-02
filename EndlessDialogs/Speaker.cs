using System;
using System.Runtime.Serialization;

namespace EndlessDialogs
{
    [Serializable]
    [DataContract]
    public class Speaker
    {
        [DataMember]
        private string name;

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
    }
}
