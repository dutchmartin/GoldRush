using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class WaterLink : OccupantLink<Ship>
    {
        public Ship Occupant { get; set; }
        public HasNext Next { get; set; }
    }
}