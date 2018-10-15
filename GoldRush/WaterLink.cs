using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class WaterLink : TrackLink
    {
        public Ship ship;

        public WaterLink()
        {
            Next = new Quay();
        }
    }
}