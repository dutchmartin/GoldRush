using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public abstract class Turnout: TrackLink
    {
        public bool isGoingUp;
        public TrackLink incoming;
        public TrackLink outgoing;
        public TrackLink option1;
        public TrackLink option2;
    }
}