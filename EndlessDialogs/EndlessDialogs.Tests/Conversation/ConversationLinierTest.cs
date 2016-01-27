using System;
using NUnit.Framework;
using NSubstitute;


namespace EndlessDialogs.Tests
{
    [TestFixture]
    public class ConversationLinierTest
    {
        IConversation conversation;
        IDialog dialog1;
        IDialog dialog2;
        IDialog dialog3;
        IDialog dialog4;

        [SetUp]
        public void Setup()
        {
            conversation = new Conversation();

            dialog1 = Substitute.For<IDialog>();
            dialog2 = Substitute.For<IDialog>();
            dialog3 = Substitute.For<IDialog>();
            dialog4 = Substitute.For<IDialog>();

            conversation.AddDialog(dialog1);
            conversation.AddDialog(dialog2);
            conversation.AddDialog(dialog3);
            conversation.AddDialog(dialog4);

            //Make dialogs linies
            dialog1.GetNext().Returns(new IDialog[] { dialog2 });
            dialog2.GetNext().Returns(new IDialog[] { dialog3 });
            dialog3.GetNext().Returns(new IDialog[] { dialog4 });
            dialog3.GetNext().Returns(new IDialog[0]);
        }

        [Test]
        public void Conversation_Should_Have_List_of_Dialogs() {

            Assert.Equals(conversation.GetAllDialogs().Length, 4);
        }

        [Test]
        public void Conversation_Can_Remove_Dialog()
        {
            conversation.RemoveDialog(dialog2);

            Assert.Equals(conversation.GetAllDialogs().Length, 3);
        }

        [Test]
        public void Should_Set_Start()
        {
            conversation.SetStartDialog(dialog1);

            Assert.Equals(conversation.Next(), dialog1);
        }

        [Test]
        public void If_Not_Set_Start_Should_Return_NULL()
        {
            Assert.IsNull(conversation.Next());
        }

        [Test]
        public void Sequince_Should_Work()
        {

            Assert.IsNull(conversation.Next());
        }
    }
}
