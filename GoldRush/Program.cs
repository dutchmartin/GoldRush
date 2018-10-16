using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldRush
{
    class Program
    {
        static void Main(string[] args)
        {
            Hangar hangar;
            Cart cart1;
            TrackLink secondTrack;
            TrackLink quayTrack;
            TrackLink fourthTrack;
            WaterQuay quay;

            WaterLink water1;
            WaterLink water2;
            WaterLink water4;
            Ship ship;

            hangar = new Hangar();
            secondTrack = new TrackLink();
            quayTrack = new TrackLink();
            fourthTrack = new TrackLink();
            water1 = new WaterLink();
            water2 = new WaterLink();
            water4 = new WaterLink();
            quay = new WaterQuay(quayTrack);
            ship = new Ship(water1);

            water1.ship = ship;
            water1.Next = water2;
            water2.Next = quay;
            quay.Next = water4;

            hangar.track.First.Next = secondTrack;
            secondTrack.Next = quayTrack;
            quayTrack.Next = fourthTrack;
            Console.ReadKey();
        }
    }
}
