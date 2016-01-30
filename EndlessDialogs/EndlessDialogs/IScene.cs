using System;
using System.Collections.Generic;

namespace EndlessDialogs
{
    public interface IScene: IBasicObject
    {
        IEnumerable<IConversation> GetConversations();

        void AddConversation(IEnumerable<IConversation> conversations);
        void AddConversation(IConversation conversation);

        void RemoveConversation(IConversation conversation);

        void RemoveConversation(IEnumerable<IConversation> conversations);
    }
}
