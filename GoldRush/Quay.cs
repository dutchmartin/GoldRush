﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Quay : TrackLink
    {
        public Ship dockedOccupant;
        public WaterLink NextWater;
    }
}