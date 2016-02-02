using System;
using System.Runtime.Serialization;

namespace EndlessDialogs
{
    [Serializable]
    [DataContract]
    public abstract class AbstractBasicObject : IBasicObject
    {
        [DataMember]
        protected string name;
        [DataMember]
        protected string description;

        public string GetDescription()
        {
            return description;
        }

        public string GetName()
        {
            return name;
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
    }
}
