using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;

namespace EndlessDialogs.Tests
{
    [TestFixture]
    public class SceneTests
    {
        IScene scene;

        IConversation conversation1;
        IConversation conversation2;
        IConversation conversation3;
        IConversation conversation4;

        [SetUp]
        public void Setup()
        {
            scene = new Scene();

            conversation1 = Substitute.For<IConversation>();
            conversation2 = Substitute.For<IConversation>();
            conversation3 = Substitute.For<IConversation>();
            conversation4 = Substitute.For<IConversation>();
        }

        [Test]
        public void Should_Add_Enumerator_Of_Conversation()
        {
            List<IConversation> listOfConv = new List<IConversation> { conversation1, conversation2, conversation3, conversation4 };

            scene.AddConversation(listOfConv);

            Assert.AreEqual(4, scene.GetConversations().Count());
        }

        [Test]
        public void Should_Add_Single_Conversation()
        {
            scene.AddConversation(conversation1);
            scene.AddConversation(conversation2);

            Assert.AreEqual(2, scene.GetConversations().Count());
        }

        [Test]
        public void Should_Not_Add_Duplicate_Conversation()
        {
            scene.AddConversation(conversation1);
            scene.AddConversation(conversation1);

            Assert.AreEqual(1, scene.GetConversations().Count());
        }

        [Test]
        public void Should_Throw_Argument_Exception_If_Add_Null_List()
        {
            List<IConversation> convList = null;
            Assert.Throws<ArgumentException>(()=> { scene.AddConversation(convList); });
        }

        [Test]
        public void Should_Throw_Argument_Exception_If_Add_Null_Conversation()
        {
            IConversation conv = null;
            Assert.Throws<ArgumentException>(() => { scene.AddConversation(conv); });
        }
    }
}
