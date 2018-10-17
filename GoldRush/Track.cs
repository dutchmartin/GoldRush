using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Track : OccupantLink<Cart>
    {
        public Cart Occupant { get; set; }
        public HasNext Next { get; set; }
        public Direction Direction { get; private set; } = Direction.NONE;

        public Track(Direction d)
        {
            Direction = d;
        }
        public Track() { }
    }
}