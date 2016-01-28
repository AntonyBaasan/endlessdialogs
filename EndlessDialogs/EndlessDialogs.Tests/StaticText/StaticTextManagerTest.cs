using System;
using NUnit.Framework;

namespace EndlessDialogs.Tests
{

    [TestFixture]
    public class StaticTextManagerTest
    {
        StaticTextDictionary stm;

        [SetUp]
        public void Setup() {
            stm = new StaticTextDictionary();
        }

        [Test]
        public void Should_Save_Text (){

            stm.AddText("player1name", "Jonh");
            stm.AddText("player2name", "Mike");
            stm.AddText("player3name", "Test");

            Assert.AreEqual(stm.GetText("player1name"), "Jonh");
        }
        [Test]
        public void Should_Throw_Exception_When_Add_NULL()
        {
            stm.AddText("player1name", "Jonh");

            Assert.Throws<ArgumentException>(() => { stm.AddText("test", null); });
            Assert.Throws<ArgumentException>(() => { stm.AddText(null, "test"); });
        }

        [Test]
        public void Should_Throw_Exception_When_Add_Empty()
        {
            stm.AddText("player1name", "Jonh");

            Assert.Throws<ArgumentException>(() => { stm.AddText("test", ""); });
            Assert.Throws<ArgumentException>(() => { stm.AddText("", "test"); });
        }
        [Test]
        public void Add_Text_Should_Update_Old_Text_If_Exists()
        {
            stm.AddText("player1name", "Jonh");
            Assert.AreEqual(stm.GetText("player1name"), "Jonh");

            stm.AddText("player1name", "Mike");
            Assert.AreEqual(stm.GetText("player1name"), "Mike");

            stm.AddText("player1name", "Test");
            Assert.AreEqual(stm.GetText("player1name"), "Test");
        }

        [Test]
        public void Should_Remove_Text()
        {
            stm.AddText("player1name", "Jonh");
            stm.RemoveText("player1name");

            Assert.AreEqual(stm.GetText("player1name"), "");
        }
    }
}
