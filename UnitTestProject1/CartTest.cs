using System;
using System.Collections.Generic;
using GoldRush;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class Carttest
    {
        Hangar hangar;
        List<Cart> carts;
        TrackLink second;
        TrackLink third;
        Cart cart1;
        Cart cart2;
        [TestInitialize]
        public void Initialise()
        {
            hangar = new Hangar();
            carts = new List<Cart>();
            second = new TrackLink();
            third = new TrackLink();

            hangar.track.First.Next = second;
            second.Next = third;
        }

        [TestMethod]
        public void AddCartToHangarTrackGetsPlacedInFirstItem()
        {
            Track track = hangar.track;
            carts.Add(hangar.AddCart());    
            Assert.IsNotNull(track.First.occupant);
            Assert.AreEqual(carts.Count, 1);
        }

        [TestMethod]
        public void CanMoveReturnsCorrectValue()
        {
            hangar.AddCart();
            cart1 = (Cart) hangar.track.First.occupant;
            Assert.IsTrue(cart1.collides());
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
            Assert.IsNull(hangar.AddCart());
        }

        [TestMethod]
        public void CartCanMove()
        {
            cart1 = hangar.AddCart();
            cart1.Move();
            Assert.IsNull(hangar.track.First.occupant);
            Assert.IsNotNull(second.occupant);
        }
        [TestMethod]
        public void TwoCloseCartsMoveWithoutCollision()
        {
            cart1 = hangar.AddCart();
            cart1.Move();
            cart1.hasMoved = false;
            cart2 = hangar.AddCart();
            cart2.Move();
            Assert.IsNull(hangar.track.First.occupant);
            Assert.IsNotNull(second.occupant);
            Assert.IsNotNull(third.occupant);
        }
        [TestMethod]
        public void CartDoesntMoveIfNextSpaceIsNull()
        {
            cart1 = hangar.AddCart();
            cart1.Move();
            cart1.hasMoved = false;
            cart1.Move();
            cart1.hasMoved = false;
            cart1.Move();
            cart1.hasMoved = false;
            Assert.IsNotNull(third.occupant);
        }
    }
}
