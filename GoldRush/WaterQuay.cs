﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class WaterQuay : WaterLink
    {
        public TrackLink Track;

        public WaterQuay()
        {
            Track = new TrackLink();
        }
    }
}