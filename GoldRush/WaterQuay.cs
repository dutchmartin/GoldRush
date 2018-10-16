using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class WaterQuay : WaterLink
    {
        public TrackLink track;

        public WaterQuay(TrackLink track)
        {
            this.track = track;
        }
    }
}