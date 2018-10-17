using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace GoldRush
{
    public class Game
    {
        public Board board {get; set;}
        private Timer timer;
        private int AmountOfCarts;
        public Game()
        {
            /* Get a board and get its hangars */
            while(true)
            {
                Play();
            }
        }

        public void Play()
        {
            #region
            /* START Test program */
            Console.WriteLine("Startgame");
            /* END */
            #endregion

            timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
            board = new Board(0, null, new List<Hangar>(), new Dictionary<char, Turnout>());
            AmountOfCarts = 1;
            while(timer.Enabled)
            {
                ChangeOrientation(InputMapper.GetInputTurnoutNumber());
                //TODO keylistning
            }
        }

        public void ChangeOrientation(int i)
        {
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Tel het aantal intervallen met elkaar op en verklein het interval daarmee
            timer.Enabled = false;
            board.MoveShips();
            board.MoveCarts();
            board.HasAddedACart(AmountOfCarts);
            board.HasAddedAShip();
            board.KeepScore();
            timer.Enabled = true;
            Console.WriteLine("Timer executes");
            //Render het board
        }

        public void ResetInterval()
        {
            /* Logica voor het resetten van de timer */
        }
    }
}