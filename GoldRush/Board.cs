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
        public Ship Ship { get; private set; }

        public Track TrackEnd { get; private set; }
        public List<Hangar> Hangars { get; private set; }
        public HashSet<Turnout> Turnouts { get; private set; }

        public Board(int score, Ship ship, Track TrackEnd, List<Hangar> hangars, HashSet<Turnout> turnouts)
        {
            Score = score;
            Ship = ship;
            TrackEnd = TrackEnd;
            Hangars = hangars;
            Turnouts = turnouts;
        }
    }
}
