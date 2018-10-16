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
        TrackLink secondTrack;
        TrackLink quayTrack;
        TrackLink fourthTrack;
        WaterQuay quay;

        WaterLink water1;
        WaterLink water2;
        WaterLink water4;
        Ship ship;

        [TestInitialize]
        public void Initialize()
        {
            hangar = new Hangar();
            secondTrack = new TrackLink();
            quayTrack = new TrackLink();
            fourthTrack = new TrackLink();
            water1 = new WaterLink();
            water2 = new WaterLink();
            water4 = new WaterLink();
            quay = new WaterQuay(quayTrack);
            ship = new Ship(water1);

            water1.ship = ship;
            water1.Next = water2;
            water2.Next = quay;
            quay.Next = water4;

            hangar.track.First.Next = secondTrack;
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
            Assert.AreEqual(quay.ship, ship);
        }
        [TestMethod]
        public void ShipGetsLoad()
        {
            cart1 = new Cart(quayTrack);
            ship.Move();
            ship.Move();
            ship.Move();
            ship.Move();
            ship.Move();
            Assert.AreEqual(ship.load, 1);
        }

    }
}
