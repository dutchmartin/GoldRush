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
        WaterQuay water2;
        WaterLink water3;

        Hangar hangar;
        Track link2;
        Track link3;
        Track link4;
        WaterQuay quay;

        [TestInitialize]
        public void Init()
        {

            /* 
            ~Q~
             Q
            -Q- - H        */
            water1 = new WaterLink();
            water2 = new WaterQuay(null);
            water3 = new WaterLink();
            hangar = new Hangar();
            link2 = new Track();
            link3 = new Track();
            link4 = new Track();
            quay = new WaterQuay(null);
            ship1 = new Ship(water1);
            water1.Next = quay;
            //quay.NextWater = water3;
            hangar.Next = link2;
            link2.Next = quay;
            quay.Next = link4;
            
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
