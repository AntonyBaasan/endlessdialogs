using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace EndlessDialogs.Tests
{
    [TestFixture]
    public class ConversationBranchingTests
    {
        IConversation conversation;
        IDialog dialog1;
        IDialog dialog2;
        IDialog dialog3;
        IDialog dialog4;
        IDialog dialog5;

        [SetUp]
        public void Setup()
        {
            conversation = new Conversation();

            dialog1 = Substitute.For<IDialog>();
            dialog2 = Substitute.For<IDialog>();
            dialog3 = Substitute.For<IDialog>();
            dialog4 = Substitute.For<IDialog>();
            dialog5 = Substitute.For<IDialog>();

            //Make dialogs linies
            dialog1.GetNext().Returns(new[] { dialog3 });
            dialog2.GetNext().Returns(new[] { dialog3 });

            dialog3.GetNext().Returns(new[] { dialog4, dialog5 });
        }

        [Test]
        public void If_Start_Is_Branched_Wait_For_Answers()
        {
            conversation.SetStartDialog(new[] { dialog1, dialog2 }.ToList());

            Assert.Throws<InvalidOperationException>(()=> { conversation.Next(); });
        }

        [Test]
        public void Answer_Should_Work()
        {
            conversation.SetStartDialog(new[] { dialog1, dialog2 }.ToList());

            IEnumerable<IDialog> nextDialogs = conversation.Answer(dialog1);

            Assert.AreEqual(1, nextDialogs.Count());
            Assert.AreEqual(dialog3, nextDialogs.First());
        }

        [Test]
        public void Answer_Throws_Argument_Exception_If_Wrong_Dialog_Passed()
        {
            conversation.SetStartDialog(new[] { dialog1, dialog2 }.ToList());

            //Pass not available answer
            Assert.Throws<ArgumentException>(() => { conversation.Answer(dialog4); });
        }

        [Test]
        public void Answer_Throws_Argument_Exception_If_Null_Dialog_Passed()
        {
            conversation.SetStartDialog(new[] { dialog1, dialog2 }.ToList());

            //Pass not available answer
            Assert.Throws<ArgumentException>(() => { conversation.Answer(null); });
        }

        [Test]
        public void Answer_Throws_Invalid_Operation_Exception_If_Not_Waiting_For_Answer()
        {
            conversation.SetStartDialog(new[] { dialog1 }.ToList());

            //Pass not available answer
            Assert.Throws<InvalidOperationException>(() => { conversation.Answer(dialog2); });
        }

        [Test]
        public void Branch1_case()
        {
            conversation.SetStartDialog(new[] { dialog1, dialog2 }.ToList());

            IEnumerable<IDialog> nextDialogs = conversation.Answer(dialog1);

            Assert.AreEqual(1, nextDialogs.Count());
            Assert.AreEqual(dialog3, nextDialogs.First());
        }

    }
}
