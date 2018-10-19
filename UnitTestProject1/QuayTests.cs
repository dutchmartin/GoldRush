using System;
using GoldRush;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class QuayTests
    {
        Hangar hangar;
        Cart cart1;
        Track secondTrack;
        Track quayTrack;
        Track fourthTrack;
        WaterQuay quay;

        WaterLink water1;
        WaterLink water2;
        WaterLink water4;
        Ship ship;

        [TestInitialize]
        public void Initialize()
        {
            hangar = new Hangar();
            secondTrack = new Track();
            quayTrack = new Track();
            fourthTrack = new Track();
            water1 = new WaterLink();
            water2 = new WaterLink();
            water4 = new WaterLink();
            quay = new WaterQuay();
            quay.track = quayTrack;
            ship = new Ship(water1);

            water1.Occupant = ship;
            water1.Next = water2;
            water2.Next = quay;
            quay.Next = water4;

            hangar.Next = secondTrack;
            secondTrack.Next = quayTrack;
            quayTrack.Next = fourthTrack;
        }
        [TestMethod]
        public void ShipStaysInPlaceWhenUnloaded()
        {
            ship.Move();
            ship.Move();
            ship.Move();
            ship.Move();
            ship.Move();
            Assert.AreEqual(quay.Occupant, ship);
        }
        [TestMethod]
        public void ShipGetsLoad()
        {
            cart1 = new Cart(quayTrack);
            ship.Move();
            ship.Move();
            ship.Move();
            cart1.Move();
            ship.Move();
            ship.Move();
            Assert.AreEqual(ship.load, 1);
        }

        [TestMethod] 
        public void ShipLeavesWhenFullyLoaded()
        {
            ship.location = quay;
            quayTrack.Occupant = null;
            cart1 = new Cart(quayTrack);
            ship.Move();
            quayTrack.Occupant = null;
            cart1 = new Cart(quayTrack);
            ship.Move();
            quayTrack.Occupant = null;
            cart1 = new Cart(quayTrack);
            ship.Move();
            quayTrack.Occupant = null;
            cart1 = new Cart(quayTrack);
            ship.Move();
            quayTrack.Occupant = null;
            cart1 = new Cart(quayTrack);
            ship.Move();
            quayTrack.Occupant = null;
            cart1 = new Cart(quayTrack);
            ship.Move();
            quayTrack.Occupant = null;
            cart1 = new Cart(quayTrack);
            ship.Move();
            quayTrack.Occupant = null;
            cart1 = new Cart(quayTrack);
            ship.Move();
            
            Assert.AreEqual(ship.load,8);
            Assert.IsNull(quay.Occupant);
            Assert.IsNotNull(water4.Occupant);
        }
        [TestMethod]
        public void ShipWaitsOnOtherBoatToMove()
        {
            ship.Move();
            Ship ship2 = new Ship(water1);
            ship.Move();
            ship2.Move();
            ship2.Move();
            ship2.Move();
            ship2.Move();
            Assert.AreEqual(water2.Occupant, ship2);
            Assert.AreEqual(quay.Occupant, ship);
        }

    }
}
