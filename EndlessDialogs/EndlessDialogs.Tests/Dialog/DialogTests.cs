using System.Linq;
using NSubstitute;
using NUnit.Framework;
namespace EndlessDialogs.Tests
{
    [TestFixture]
    public class DialogTests
    {
        IDialog dialog1;
        IDialog dialog2;
        IDialog dialog3;
        IDialog dialog4;

        [SetUp]
        public void Setup()
        {
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
        public void Get_Next_Should_Return_Next_Dialogs()
        {
            Assert.AreEqual(2, 1);
        }
    }
}
