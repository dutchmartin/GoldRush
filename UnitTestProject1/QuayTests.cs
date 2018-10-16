using System;
using GoldRush;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class QuayTests
    {
        Hangar hangar;
        TrackLink second;
        TrackLink fourth;
        Quay quay;
        Ship ship;

        [TestInitialize]
        public void Initialize()
        {
            hangar = new Hangar();
            second = new TrackLink();
            fourth = new TrackLink();
            quay = new Quay();
            ship = new Ship();

            hangar.track.First.Next = second;
            second.Next = quay;
            quay.Next = fourth;
            quay.dockedOccupant = ship;
        }
        [TestMethod]
        public void CartEmpties()
        {
            hangar.AddCart();
            Cart cart1 = (Cart) hangar.track.First.occupant;
            hangar.moveCarts();
            Assert.IsTrue(cart1.isLoaded);
            Assert.IsFalse(cart1.isLoaded);
        }
    }
}
