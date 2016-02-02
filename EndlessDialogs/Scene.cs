using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace EndlessDialogs
{
    [Serializable]
    [DataContract]
    [KnownType(typeof(Scene))]
    public class Scene : AbstractBasicObject, IScene
    {
        [DataMember]
        private List<IConversation> conversationList;

        private static IEnumerable<Type> _sceneTypes;

        public Scene()
        {
            conversationList = new List<IConversation>();
        }

        public void AddConversation(IConversation conversation)
        {
            if (conversation == null)
                throw new ArgumentException("Can't add Null Conversation!");

            if (conversationList.Contains(conversation))
                return;

            conversationList.Add(conversation);
        }

        public void AddConversation(IEnumerable<IConversation> conversations)
        {
            if (conversations == null)
                throw new ArgumentException("Can't add Null Conversation List!");

            foreach (var conv in conversations)
            {
                conversationList.Add(conv);
            }
        }

        public IEnumerable<IConversation> GetConversations()
        {
            return conversationList;
        }

        public void RemoveConversation(IEnumerable<IConversation> conversations)
        {
            foreach (var conversation in conversations)
            {
                RemoveConversation(conversation);
            }
        }

        public void RemoveConversation(IConversation conversation)
        {
            conversationList.Remove(conversation);
        }

        //private static IEnumerable<Type> GetKnownSceneTypes()
        //{
        //    if (_sceneTypes == null)
        //        _sceneTypes = Assembly.GetExecutingAssembly()
        //                                .GetTypes()
        //                                .Where(t => typeof(Scene).IsAssignableFrom(t))
        //                                .ToList();
        //    return _sceneTypes;
        //}
    }
}
