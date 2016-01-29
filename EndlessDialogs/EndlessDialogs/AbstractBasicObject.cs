namespace EndlessDialogs
{
    public abstract class AbstractBasicObject : IBasicObject
    {
        protected string name;
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
