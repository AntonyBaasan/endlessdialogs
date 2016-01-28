using System;

namespace EndlessDialogs
{
    public abstract class AbstractBasicObject : IBasicObject
    {
        protected string Name;
        protected string Description;

        public string GetDescription()
        {
            return Description;
        }

        public string GetName()
        {
            return Name;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}
