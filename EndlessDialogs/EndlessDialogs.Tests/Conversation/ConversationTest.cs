using System;
using NUnit.Framework;
using NSubstitute;


namespace EndlessDialogs.Tests
{
    [TestFixture]
    public class ConversationTest
    {
        [Test]
        public void Conversation_Should_Have_List_of_Dialogs() {
            IConversation c = new Conversation();

            Assert.Equals(1, 1);
        }
    }
}
