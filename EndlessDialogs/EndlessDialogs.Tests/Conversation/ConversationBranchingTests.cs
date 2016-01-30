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
            dialog1.GetText().Returns("Dialog1");
            dialog2 = Substitute.For<IDialog>();
            dialog2.GetText().Returns("Dialog2");
            dialog3 = Substitute.For<IDialog>();
            dialog3.GetText().Returns("Dialog3");
            dialog4 = Substitute.For<IDialog>();
            dialog4.GetText().Returns("Dialog4");
            dialog5 = Substitute.For<IDialog>();
            dialog5.GetText().Returns("Dialog5");

            //Make dialogs linies
            dialog1.GetNext().Returns(new[] { dialog3 });
            dialog2.GetNext().Returns(new[] { dialog3 });

            dialog3.GetNext().Returns(new[] { dialog4, dialog5 });
        }

        [Test]
        public void If_Start_Is_Branched_Get_Available_Dialogs()
        {
            conversation.SetStartDialog(new[] { dialog1, dialog2 }.ToList());

            Assert.AreEqual(2, conversation.Next().Count());
        }

        [Test]
        public void Answer_Should_Work()
        {
            conversation.SetStartDialog(new[] { dialog1, dialog2 }.ToList());

            conversation.Next();
            conversation.Answer(dialog1);
            IEnumerable<IDialog> nextDialogs = conversation.Next();

            Assert.AreEqual(1, nextDialogs.Count());
            Assert.AreEqual(dialog3, nextDialogs.First());
        }

        [Test]
        public void Answer_Throws_Argument_Exception_If_Wrong_Dialog_Passed()
        {
            conversation.SetStartDialog(new[] { dialog1, dialog2 }.ToList());
            conversation.Next();

            //Pass not available answer
            Assert.Throws<ArgumentException>(() => { conversation.Answer(dialog4); });
        }

        [Test]
        public void Answer_Throws_Argument_Exception_If_Null_Dialog_Passed()
        {
            conversation.SetStartDialog(new[] { dialog1, dialog2 }.ToList());
            conversation.Next();

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

            conversation.Next();
            conversation.Answer(dialog1);
            IEnumerable<IDialog> nextDialogs = conversation.Next();

            Assert.AreEqual(1, nextDialogs.Count());
            Assert.AreEqual(dialog3, nextDialogs.First());
        }

        [Test]
        public void Get_Next_Should_Call_Visited_On_Dialog()
        {
            conversation.SetStartDialog(new[] { dialog1 }.ToList());

            conversation.Next();

            dialog1.Received().Visit();
        }

        [Test]
        public void Get_Next_Should_Not_Call_Visited_If_It_Return_Answers()
        {
            conversation.SetStartDialog(new[] { dialog1, dialog2 }.ToList());
            conversation.Next();

            dialog1.Received().Visit();
            dialog2.Received().Visit();
        }

        [Test]
        public void Answer_Should_Not_Call_Visited_On_Answer()
        {
            conversation.SetStartDialog(new[] { dialog1, dialog2 }.ToList());

            conversation.Next();
            conversation.Answer(dialog1);

            dialog1.Received(1).Visit();
        }

        [Test]
        public void Answer_Should_Call_Visited_On_Next_If_That_Is_Not_Answers()
        {
            try
            {
                conversation.SetStartDialog(new[] { dialog1, dialog2 }.ToList());

                conversation.Answer(dialog3);
            }
            catch
            {
            }

            dialog1.DidNotReceive().Visit();
            dialog2.DidNotReceive().Visit();
        }

        [Test]
        public void If_Waiting_For_Answer_Throw_Invalid_Operation_Exception()
        {
            conversation.SetStartDialog(new[] { dialog1, dialog2 }.ToList());

            conversation.Next();
            Assert.Throws<InvalidOperationException>(() => { conversation.Next(); });
        }

        [Test]
        public void If_Waiting_For_Answer_And_Answered_Correctly_GetNext_Should_Work_Correctly()
        {
            Dialog d1 = new Dialog() {text = "d1"};
            Dialog d2 = new Dialog() {text = "d2"};
            Dialog d3 = new Dialog() {text = "d3"};
            Dialog d4 = new Dialog() {text = "d4"};
            Dialog d5 = new Dialog() {text = "d5" };

            d1.AddNext(d3);
            d2.AddNext(d3);
            d3.AddNext(new[] { d4, d5 });

            conversation.SetStartDialog(new[] { d1, d2 }.ToList());

            conversation.Next();
            conversation.Answer(d1);//return Dialog3
            IEnumerable<IDialog> nextDialogs = conversation.Next();
            Assert.AreEqual(d3, nextDialogs.First());

            nextDialogs = conversation.Next();
            //Assert.AreEqual(dialog3, nextDialogs.First());
            Assert.AreEqual(d4, nextDialogs.First());
        }

    }
}
