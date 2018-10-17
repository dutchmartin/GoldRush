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
        Track second;
        Track third;
        Cart cart1;
        Cart cart2;
        Yard yard1;
        Yard yard2;
        [TestInitialize]
        public void Initialise()
        {
            hangar = new Hangar();
            carts = new List<Cart>();
            second = new Track();
            third = new Track();
            yard1 = new Yard();
            yard2 = new Yard();

            hangar.Next = second;
            second.Next = third;
        }

        [TestMethod]
        public void AddCartToHangarTrackGetsPlacedInFirstItem()
        {
            carts.Add(hangar.AddCart());    
            Assert.IsNotNull(hangar.Occupant);
            Assert.AreEqual(carts.Count, 1);
        }

        [TestMethod]
        public void CanMoveReturnsCorrectValue()
        {
            hangar.AddCart();
            cart1 = (Cart) hangar.Occupant;
            Assert.IsTrue(cart1.canMove());
        }
        [TestMethod]
        public void NewHangarTrackIsEmpty()
        {
            Assert.IsNull(hangar.Occupant);
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
            Assert.IsNull(hangar.Occupant);
            Assert.IsNotNull(second.Occupant);
        }
        [TestMethod]
        public void TwoCloseCartsMoveWithoutCollision()
        {
            cart1 = hangar.AddCart();
            cart1.Move();
            cart1.hasMoved = false;
            cart2 = hangar.AddCart();
            cart2.Move();
            Assert.IsNull(hangar.Occupant);
            Assert.IsNotNull(second.Occupant);
            Assert.IsNotNull(third.Occupant);
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
            Assert.IsNotNull(third.Occupant);
        }
        [TestMethod]
        public void CartDoestnCrashOnYard()
        {
            third.Next = yard1;
            yard1.Next = yard2;
            cart1 = hangar.AddCart();
            cart1.Move();
            cart1.hasMoved = false;
            cart2 = hangar.AddCart();
            cart2.Move();
            cart1.hasMoved = false;
            cart2.hasMoved = false;
            cart2.Move();
            cart1.hasMoved = false;
            cart2.hasMoved = false;
            cart2.Move();
            cart1.hasMoved = false;
            cart2.hasMoved = false;
            cart2.Move();
            cart1.hasMoved = false;
            cart2.hasMoved = false;
            cart2.Move();
            cart1.hasMoved = false;
            cart2.hasMoved = false;
            cart2.Move();
            cart1.hasMoved = false;
            cart2.hasMoved = false;
            cart2.Move();
            cart1.hasMoved = false;
            cart2.hasMoved = false;
            cart2.Move();
            cart1.hasMoved = false;
            cart2.hasMoved = false;
            Assert.AreEqual(yard1.Occupant, cart2);
            Assert.AreEqual(yard2.Occupant, cart1);
        }
        [TestMethod]
        [ExpectedException (typeof(CartCrashException))]
        public void CartCrashesAgainstYard()
        {
            third.Next = yard1;
            cart1 = hangar.AddCart();
            cart1.Move();
            cart1.hasMoved = false;
            cart2 = hangar.AddCart();
            cart1.hasMoved = false;
            cart2.hasMoved = false;
            cart2.Move();
            cart1.hasMoved = false;
            cart2.hasMoved = false;
            cart2.Move();
            cart1.hasMoved = false;
            cart2.hasMoved = false;
            cart2.Move();
            cart1.hasMoved = false;
            cart2.hasMoved = false;
            cart2.Move();
            cart1.hasMoved = false;
            cart2.hasMoved = false;
            cart2.Move();
            cart1.hasMoved = false;
            cart2.hasMoved = false;
            cart2.Move();
            cart1.hasMoved = false;
            cart2.hasMoved = false;
            cart2.Move();
            cart1.hasMoved = false;
            cart2.hasMoved = false;
        }

        [TestMethod]
        [ExpectedException (typeof(CartCrashException))]
        public void CartCrashAgainstStilStandingCart()
        {
            cart1 = hangar.AddCart();
            cart1.Move();
            cart1.hasMoved = false;
            cart2 = hangar.AddCart();
            cart1.hasMoved = false;
            cart2.hasMoved = false;
            cart2.Move();
            cart1.hasMoved = false;
            cart2.hasMoved = false;
            cart2.Move();
        }
    }
}
