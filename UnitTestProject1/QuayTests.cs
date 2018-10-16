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
        Ship quay;

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
            quay = new Ship(quayTrack);
            ship = new Ship();

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
            Cart cart1 = (Cart) hangar.track.First.occupant;
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
        }

    }
}
