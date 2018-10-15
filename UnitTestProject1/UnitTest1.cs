using System;
using System.Collections.Generic;
using GoldRush;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        Hangar hangar;
        [TestInitialize]
        public void Initialise()
        {
            hangar = new Hangar();
        }

        [TestMethod]
        public void AddCartToHangarTrackGetsPlacedInFirstItem()
        {
            Track track = hangar.track;
            hangar.AddCart();
            Assert.IsNotNull(track.First.occupant);
        }

        [TestMethod]
        public void CanMoveReturnsCorrectValue()
        {
            hangar.AddCart();
            TrackLink second = new TrackLink();
            hangar.track.First.Next = second;
            Cart cart1 = hangar.track.First.occupant;
            Assert.IsTrue(cart1.canMove());
        }
        [TestMethod]
        public void CantMoveReturnsFalse()
        {
            hangar.AddCart();
            Cart cart1 = hangar.track.First.occupant;
            Assert.IsFalse(cart1.canMove());    
        }

        [TestMethod]
        public void NewHangarTrackIsEmpty()
        {
            Assert.IsNull(hangar.track.First.occupant);
        }

        [TestMethod]
        public void AddCartToOccupiedTrackDoesNotAdd()
        {
            hangar.AddCart();
            Assert.IsFalse(hangar.AddCart());
        }

        [TestMethod]
        public void CartCanMove()
        {
            TrackLink second = new TrackLink();
            hangar.track.First.Next = second;
            hangar.AddCart();
            hangar.moveCarts();
            Assert.IsNull(hangar.track.First.occupant);
            Assert.IsNotNull(second.occupant);
        }
        [TestMethod]
        public void TrackGetsAllCarts()
        {
            TrackLink second = new TrackLink();
            TrackLink third = new TrackLink();
            Cart firstCart = new Cart(hangar.track.First);
            Cart secondCart = new Cart(second);
            hangar.track.First.Next = second;
            second.Next = third;
            hangar.track.First.occupant = firstCart;
            second.occupant = secondCart;
            Track track = hangar.track;
            Stack<Cart> carts  = track.createCartsQueue();
            Assert.AreEqual(carts.Count, 2);
            Assert.AreEqual(carts.Pop(), secondCart);
            Assert.AreEqual(carts.Count, 1);
            Assert.AreEqual(carts.Pop(), firstCart);
        }
        [TestMethod]
        public void HangarGetsAllCarts()
        {
            TrackLink second = new TrackLink();
            TrackLink third = new TrackLink();
            hangar.track.First.Next = second;
            second.Next = third;
            hangar.AddCart();
            hangar.moveCarts();
            hangar.AddCart();
            Stack<Cart> carts = hangar.track.createCartsQueue();
            Assert.AreEqual(carts.Count, 2);

        }
        [TestMethod]
        public void TwoCloseCartsMoveWithoutCollision()
        {
            TrackLink second = new TrackLink();
            TrackLink third = new TrackLink();
            second.Next = third;
            hangar.track.First.Next = second;
            hangar.AddCart();
            hangar.moveCarts();
            hangar.AddCart();
            hangar.moveCarts();
            Assert.IsNull(hangar.track.First.occupant);
            Assert.IsNotNull(second.occupant);
            Assert.IsNotNull(third.occupant);
        }
        [TestMethod]
        public void CartDoesntMoveIfNextSpaceIsNull()
        {
            TrackLink second = new TrackLink();
            hangar.track.First.Next = second;
            hangar.AddCart();
            hangar.moveCarts();
            hangar.moveCarts();
            Assert.IsNotNull(second.occupant);
        }
    }
}
