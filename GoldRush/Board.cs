using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldRush
{
    public class Board
    {
        public int Score { get; private set; }
        public Quay Quay { get; private set; }

        public TrackLink TrackLinkEnd { get; private set; }
        public List<Hangar> Hangars { get; private set; }
        public HashSet<Turnout> Turnouts { get; private set; }
    }
}
