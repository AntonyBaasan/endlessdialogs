using System.Collections.Generic;

namespace EndlessDialogs
{
    public interface IScene: IBasicObject
    {
        IEnumerable<IConversation> GetConversations();

        void AddConversation(IEnumerable<IConversation> conversation);

        void AddConversation(IConversation conversation);

        void RemoveConversation(IConversation conversation);

        void RemoveConversation(IEnumerable<IConversation> conversation);

        void LoadScene(string filename);

        void SaveScene(string filename);
    }
}
