using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Game
    {
        int score;
        Turnout[] turnouts;
        Hangar[] hangars;
        Ship[] ships;

        public Game()
        {
            Hangar A = new Hangar();
            Hangar B = new Hangar();
            Hangar C = new Hangar();
            hangars = new Hangar[3];
            turnouts = new Turnout[5];
            hangars[0] = A;
            hangars[1] = B;
            hangars[2] = C;

            /* Een current track link maken om het track op te bouwen */
            TrackLink CurrentA = A.track.First;
            TrackLink CurrentB = B.track.First;
            TrackLink CurrentC = C.track.First;

            CurrentA.Next = new TrackLink();
            CurrentA = CurrentA.Next;
            CurrentB.Next = new TrackLink();
            CurrentB = CurrentB.Next;            
        }
    }
}