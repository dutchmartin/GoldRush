using GoldRush.GameConstruction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace GoldRush
{
    public class Game : IObservable<GameData>
    {
        public Board board {get; set;}
        private Timer timer;
        private int timeinterval;
        private int AmountOfCarts;
        private View.ObserverList<IObserver<GameData>> ObserverList = new View.ObserverList<IObserver<GameData>>();
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
            BoardBuilder builder = new BoardBuilder();
            board = builder.BuildBoard();
            #region
            /* START Test program */
            Console.WriteLine("Startgame");
            /* END */
            #endregion

            timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
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
            board.HasAddedACart();
            board.HasAddedAShip();
            board.KeepScore();
            board.AdjustAmountOfCarts();
            timer.Interval = board.GetTimeInterval();
            timer.Enabled = true;
            Console.WriteLine("Timer executes");
            Console.WriteLine(board.Carts.Count.ToString());
            Console.WriteLine(board.Ships.Count.ToString());
            //Render het board
        }

        public void ResetInterval()
        {
            /* Logica voor het resetten van de timer */
        }

        public IDisposable Subscribe(IObserver<GameData> observer)
        {
            ObserverList.Add(observer);
            return ObserverList;
        }
        private 
    }
}