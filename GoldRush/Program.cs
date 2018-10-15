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
            Hangar hangar = new Hangar();
            TrackLink second = new TrackLink();
            TrackLink third = new TrackLink();
            second.Next = third;
            hangar.track.First.Next = second;
            hangar.AddCart();
            hangar.moveCarts();
            hangar.AddCart();
            hangar.moveCarts();
            Console.ReadKey();
        }
    }
}
