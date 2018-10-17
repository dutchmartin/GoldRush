using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldRush.GameConstruction
{
    public sealed class BoardBuilder
    {
        private HasNext[][] _hasNexts { get; set; }
        private static Char[] KeyChars = "qwertyuiop".ToCharArray();

        // Board Properties.
        public Track TrackEnd { get; private set; }
        public List<Hangar> Hangars { get; private set; } = new List<Hangar>();
        public Dictionary<char,Turnout> Turnouts { get; private set; } = new Dictionary<char, Turnout>();

        public BoardBuilder()
        {
            _hasNexts = HasNext2DArrayFactory.Instance.GetHasNext2DArray();
        }

        public Board BuildBoard()
        {
            LayLinks();
            return new Board(0, TrackEnd, Hangars, Turnouts);
        }

        public void LayLinks()
        {
            if (_hasNexts == null)
            {
                throw new InvalidOperationException();
            }
            // Loop over array.
            for (int y = 0; y < _hasNexts.Length; y++)
            {
                for (int x = 0; x < _hasNexts[y].Length; x++)
                {
                    // Check is item is null
                    if (_hasNexts[y][x] == null)
                        continue;
                    // Yeey, we found a item, Lets check its identity.
                    switch (_hasNexts[y][x])
                    {
                        case Hangar hangar:
                            // Look right for a tracklink and link to it.
                            if (IsType<Track>(y, x + 1))
                            {
                                hangar.Next = _hasNexts[y] [x + 1];
                                Hangars.Add(hangar);
                            }
                            continue;
                        case Yard yard:
                            // Look Left for another yard.
                            if(IsType<Yard>(y, x - 1))
                            {
                                yard.Next = _hasNexts[y][x - 1];
                            }
                            continue;
                        case Turnout1To2 turnout1To2:
                            // Look up and down.
                            LinkTurnout(turnout1To2, y, x);
                            // Look left

                            continue;
                        case Turnout2To1 turnout2To1:
                            // Look up and down.
                            LinkTurnout(turnout2To1, y, x);
                            // Look right
                            if (IsType<Track>(y, x - 1))
                            {
                                turnout2To1.Next = _hasNexts[y][x - 1];
                            }
                            continue;
                        case Track track when track.GetType() == typeof(Track):
                            LinkTracks(track, y, x);
                            continue;
                    }
                }
            }
        }
        private bool IsType<T>(int y, int x)
        {
            // Check bounds.
            if (x >= _hasNexts.Length || y >= _hasNexts.First().Length || x < 0 || x < 0)
                return false;
            return _hasNexts[y][x] is T;
        }
        private void LinkTurnout(Turnout turnout, int y, int x)
        {
            // Look above for a Track.
            if (IsType<Track>(y + 1, x))
            {
                turnout.optionUp = _hasNexts[y + 1][x] as Track;
            }
            // Look above for a Track.
            if (IsType<Track>(y - 1, x))
            {
                turnout.optionUp = _hasNexts[y - 1][x] as Track;
            }
            Turnouts.Add(KeyChars[Turnouts.Count], turnout);
        }
        private void LinkTracks(Track track, int y, int x)
        {
            // Switch direction
            switch(track.Direction)
            {
                case Direction.DOWN:
                    AddNext<Track>(track, y + 1, x);
                    return;
                case Direction.LEFT:
                    AddNext<Track>(track, y, x - 1);
                    return;
                case Direction.RIGHT:
                    AddNext<Track>(track, y, x + 1);
                    return;
                case Direction.UP:
                    AddNext<Track>(track, y - 1, x);
                    return;
            }
        }
        private void AddNext<T>(HasNext nextObject, int y, int x)
        {
            if (IsType<T>(y, x))
            {
                nextObject.Next = _hasNexts[y][x];
            }
        }
    }
}
