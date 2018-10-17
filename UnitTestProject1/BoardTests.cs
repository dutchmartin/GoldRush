using System;
using System.Collections.Generic;
using GoldRush;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class BoardTests
    {
        Board board;
        Track hangar1Track2;
        Track hangar2Track2;
        Track hangar1Track3;
        [TestInitialize]
        public void Init()
        {
            List<Hangar> hangars = new List<Hangar>();
            HashSet<Turnout> turnouts = new HashSet<Turnout>();
            Hangar hangar1 = new Hangar();
            Hangar hangar2 = new Hangar();
            hangar1Track2 = new Track();
            hangar2Track2 = new Track();
            hangar1Track3 = new Track();
            Turnout1To2 turnout1 = new Turnout1To2();
            Turnout2To1 turnout2 = new Turnout2To1();

            hangar1.Next = hangar1Track2;
            hangar1Track2.Next = hangar1Track3;

            hangar2.Next = hangar2Track2;

            hangars.Add(hangar1);
            hangars.Add(hangar2);

            turnouts.Add(turnout1);
            turnouts.Add(turnout2);

            board = new Board(0, null, hangars, turnouts);

        }
        [TestMethod]
        public void NewBoardHasEmptyCarts()
        {
            Assert.AreEqual(board.Carts.Count, 0);
        }

        [TestMethod]
        public void NewBoardHasCorrectAmountOfHangars()
        {
            Assert.AreEqual(board.Hangars.Count, 2);
        }
        [TestMethod]
        public void NewBoardHasCorrectAmountOfTurnouts()
        {
            Assert.AreEqual(board.Turnouts.Count, 2);
        }
        [TestMethod]
        public void AddCartAddsOneCartToCarts()
        {
            board.AddCarts(1);
            Assert.AreEqual(board.Carts.Count, 1);
        }
        [TestMethod]
        public void AddingMultipleCartsAddsCorrectAmountOfCarts()
        {
            board.AddCarts(2);
            Assert.AreEqual(board.Carts.Count, 2);
        }
        [TestMethod]
        public void AddingTooManyCartsWontWork()
        {
            bool result = board.AddCarts(3);
            Assert.AreEqual(board.Carts.Count, 0);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void AllCartsMove()
        {
            board.AddCarts(2);
            board.MoveCarts();
            Assert.IsNull(board.Hangars[0].Occupant);
            Assert.IsNull(board.Hangars[1].Occupant);
            Assert.IsNotNull(hangar1Track2);
            Assert.IsNotNull(hangar2Track2);
        }
        [TestMethod]
        public void CartsMoveCorrectly()
        {
            board.AddCarts(2);
            board.MoveCarts();
            board.MoveCarts();
            Assert.IsNotNull(hangar1Track3);
            Assert.IsNotNull(hangar2Track2);
        }
        [TestMethod]
        [ExpectedException (typeof(CartCrashException))]
        public void CartsCrash()
        {
            board.AddCarts(2);
            board.MoveCarts();
            board.AddCarts(2);
            board.MoveCarts();
        }
    }
}
