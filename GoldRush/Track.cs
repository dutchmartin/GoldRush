using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Track : OccupantLink<Cart>
    {
        public Cart Occupant { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public HasNext Next { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}