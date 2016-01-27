using NUnit.Framework;

namespace EndlessDialogs.Tests.StaticText
{
    [TestFixture]
    class StaticTextManagerTest
    {
        [Test]
        public void Static_Text_Manager_Should_Save_Text (){
            StaticTextManager stm = new StaticTextManager();

            stm.AddText("player1name", "Jonh");
            stm.AddText("player2name", "Mike");
            stm.AddText("player3name", "Test");

            Assert.Equals(stm.GetText("player1name"), "Jonh");
        }
    }
}
