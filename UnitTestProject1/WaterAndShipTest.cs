using System;
using GoldRush;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class WaterAndShipTest
    {
        Ship ship1;
        WaterLink water1;
        WaterLink water3;

        Hangar hangar;
        TrackLink link2;
        TrackLink link4;
        Quay quay;

        [TestInitialize]
        public void Init()
        {

            /* 
            ~Q~
             Q
            -Q- - H        */
            ship1 = new Ship();
            water1 = new WaterLink();
            water3 = new WaterLink();
            hangar = new Hangar();
            link2 = new TrackLink();
            link4 = new TrackLink();
            quay = new Quay();
            water1.Next = quay;
            quay.NextWater = water3;
            hangar.track.First.Next = link2;
            link2.Next = quay;
            quay.Next = link4;
            
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
