using NUnit.Framework;

namespace EndlessDialogs.Tests.StaticText
{

    [TestFixture]
    class StaticTextManagerTest
    {
        StaticTextManager stm;

        [SetUp]
        public void Setup() {
            stm = new StaticTextManager();
        }

        [Test]
        public void Should_Save_Text (){

            stm.AddText("player1name", "Jonh");
            stm.AddText("player2name", "Mike");
            stm.AddText("player3name", "Test");

            Assert.Equals(stm.GetText("player1name"), "Jonh");
        }

        [Test]
        public void Add_Text_Should_Update_Old_Text_If_Exists()
        {
            stm.AddText("player1name", "Jonh");
            Assert.Equals(stm.GetText("player1name"), "Jonh");

            stm.AddText("player1name", "Mike");
            Assert.Equals(stm.GetText("player1name"), "Mike");

            stm.AddText("player1name", "Test");
            Assert.Equals(stm.GetText("player1name"), "Test");
        }

        [Test]
        public void Should_Remove_Text()
        {
            stm.AddText("player1name", "Jonh");
            stm.RemoveText("player1name");

            Assert.Equals(stm.GetText("player1name"), "{player1name}");
        }
    }
}
