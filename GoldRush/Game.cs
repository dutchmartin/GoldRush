using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace GoldRush
{
    public class Game
    {
        Board board {get; set;}
        int Score = 0;
        Timer timer;
        int interval;
        public Game()
        {
            interval = 5000;
            timer = new Timer(interval);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Render het board
            //Tel het aantal intervallen met elkaar op en verklein het interval daarmee
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
            Console.WriteLine(timer.Interval);
            timer.Interval -= 100;
        }
    }
}