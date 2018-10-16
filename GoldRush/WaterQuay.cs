using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Ship : WaterLink
    {
        public TrackLink track;

        public Ship(TrackLink track)
        {
            this.track = track;
        }
    }
}