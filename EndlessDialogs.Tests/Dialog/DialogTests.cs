using System;
using System.Collections.Generic;
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
            dialog1 = new Dialog();

            dialog2 = Substitute.For<Dialog>();
            dialog3 = Substitute.For<Dialog>();
            dialog4 = Substitute.For<Dialog>();

        }

        [Test]
        public void Add_Next_Should_Increase_Its_Dialogs_Amount()
        {
            dialog1.AddNext(dialog2);
            dialog1.AddNext(dialog3);

            Assert.AreEqual(2, dialog1.GetNext().Count());
        }

        [Test]
        public void Add_Next_Array_Should_Increase_Its_Dialogs_Amount()
        {
            dialog1.AddNext(new [] { dialog2, dialog3 }); 

            Assert.AreEqual(2, dialog1.GetNext().Count());
        }

        [Test]
        public void Add_Next_Throws_Argument_Exception_If_Null_Passed()
        {
            IDialog dialog = null;
            Assert.Throws<ArgumentException>(() => { dialog1.AddNext(dialog); });
        }

        [Test]
        public void Get_Next_Should_Return_Next_Dialogs()
        {
            dialog1.AddNext(dialog2);

            IDialog gotten = dialog1.GetNext().First();
            Assert.AreEqual(dialog2, gotten);
        }

        [Test]
        public void Get_Next_Should_Return_Null_If_No_Dialogs()
        {
            Assert.IsNull(dialog1.GetNext());
        }

        [Test]
        public void Add_Next_Throws_Argument_Exception_If_Empty_List_Passed()
        {
            List<IDialog> list = new List<IDialog>();//empty list
            Assert.Throws<ArgumentException>(() => { dialog1.AddNext(list); });
        }

        [Test]
        public void Visited_Method_Should_Increase_VistedAmount()
        {
            Assert.AreEqual(0, dialog1.VisitedAmout());

            dialog1.Visit();
            Assert.AreEqual(1, dialog1.VisitedAmout());

        }

        [Test]
        public void Should_Not_Add_Next_Self_Argument_Exception_Throws()
        {
            Assert.Throws<ArgumentException>(() => { dialog1.AddNext(dialog1); });
        }

    }
}
