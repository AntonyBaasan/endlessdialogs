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

        [SetUp]
        public void Setup()
        {
            scene = new Scene();

        }

        [Test]
        public void Add_Next_Should_Increase_Its_Dialogs_Amount()
        {
            Assert.AreEqual(2, 1);
        }
    }
}
