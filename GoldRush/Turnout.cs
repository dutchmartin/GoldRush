using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public abstract class Turnout: TrackLink
    {
        TrackLink incoming;
        TrackLink outgoing;
        TrackLink option1;
        TrackLink option2;
    }
}