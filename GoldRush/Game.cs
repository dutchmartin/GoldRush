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
        Timer timer;
        int AmountOfCarts;
        public Game()
        {
            /* Get a board and get its hangars */
            timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            Board board = new Board(0, null, new List<Hangar>(), new HashSet<Turnout>());
            AmountOfCarts = 1;
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Render het board
            //Tel het aantal intervallen met elkaar op en verklein het interval daarmee
            /* TODO: MOVE SHIPS
            TODO: MOVE ALL CARTS
            TODO: ADD CART */
            board.MoveShips();
            board.MoveCarts();
            board.AddCarts(AmountOfCarts);
        }

        public void ResetInterval()
        {
            /* Logica voor het resetten van de timer */
        }
    }
}