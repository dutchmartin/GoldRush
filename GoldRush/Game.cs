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
            interval = 2;
            timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Render het board
            //Tel het aantal intervallen met elkaar op en verklein het interval daarmee
            Console.WriteLine("The Elapsed event was raised at {0:HH:mm:ss.fff}", e.SignalTime);
            Console.WriteLine(interval);
            interval--;
            if (interval == 0)
            {
                timer.Stop();
                /* start game logica */
                ResetInterval();
                timer.Start();
            }
        }

        public void ResetInterval()
        {
            /* Logica voor het resetten van de timer */
            interval = 2;
        }
    }
}