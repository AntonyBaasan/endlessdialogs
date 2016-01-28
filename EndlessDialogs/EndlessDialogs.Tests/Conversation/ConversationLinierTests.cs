using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace EndlessDialogs.Tests
{
    [TestFixture]
    public class ConversationLinierTests
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

            //Make dialogs linies
            dialog1.GetNext().Returns(new[] { dialog2 });
            dialog2.GetNext().Returns(new[] { dialog3 });
            dialog3.GetNext().Returns(new[] { dialog4 });
            dialog4.GetNext().Returns(new IDialog[0]);
        }


        [Test]
        public void Should_Set_Start()
        {
            conversation.SetStartDialog(new[] { dialog1 }.ToList());

            Assert.AreEqual(dialog1, conversation.Next().First());
        }

        [Test]
        public void If_Not_Set_Start_Should_Return_NULL()
        {
            Assert.IsNull(conversation.Next());
        }

        [Test]
        public void Sequince_Should_Work()
        {
            conversation.SetStartDialog(new[] { dialog1 }.ToList());

            Assert.AreEqual(conversation.Next().First(), dialog1);
            Assert.AreEqual(conversation.Next().First(), dialog2);
            Assert.AreEqual(conversation.Next().First(), dialog3);
            Assert.AreEqual(conversation.Next().First(), dialog4);
            Assert.IsNull(conversation.Next());
        }
    }
}
