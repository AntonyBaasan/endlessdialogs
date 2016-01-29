using System;
using System.Collections.Generic;

namespace EndlessDialogs
{
    public class Scene : AbstractBasicObject, IScene
    {
        public void AddConversation(IConversation conversation)
        {
            throw new NotImplementedException();
        }

        public void AddConversation(IEnumerable<IConversation> conversation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IConversation> GetConversations()
        {
            throw new NotImplementedException();
        }

        public void LoadScene(string filename)
        {
            throw new NotImplementedException();
        }

        public void RemoveConversation(IEnumerable<IConversation> conversation)
        {
            throw new NotImplementedException();
        }

        public void RemoveConversation(IConversation conversation)
        {
            throw new NotImplementedException();
        }

        public void SaveScene(string filename)
        {
            throw new NotImplementedException();
        }
    }
}
