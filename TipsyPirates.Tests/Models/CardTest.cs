using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TipsyPirates.Models;

namespace TipsyPirates.Tests.Models
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void TestMoveCardInitialisation()
        {
            Card card = new MoveCard();
            Assert.AreEqual(card.Commands[0], Enums.CommandType.Move);
        }
    }
}
