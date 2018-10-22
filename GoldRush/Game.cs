using GoldRush.Controller;
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
        public Board board { get; set; }
        public InputController InputController { get; set; } = new InputController();
        private Timer timer;
        private Boolean isGameEnded;
        private View.ObserverList<IObserver<GameData>, GameData> ObserverList = new View.ObserverList<IObserver<GameData>, GameData>();

        public void Play()
        {
            BoardBuilder builder = new BoardBuilder();
            board = builder.BuildBoard();

            this.timer = new Timer(1000)
            {
                AutoReset = false
            };
            StartInputPeriod();
        }
        public void StartInputPeriod()
        {
            this.timer.Start();
            while (timer.Enabled)
            {
                // Todo: write time of timer to screen.
                Render();
                char input = InputController.GetKeyInput();
                ChangeTurnoutOrientation(input);
            }
            try
            {
                this.Tick();
            }
            catch(Exception e)
            {
                // End game.
                return;
            }
            System.Threading.Thread.Sleep(20);
            StartInputPeriod();
        }

        public void ChangeTurnoutOrientation(char c)
        {
            board.ToggleTurnout(c);
        }

        public void Tick()
        {
            //Tel het aantal intervallen met elkaar op en verklein het interval daarmee
            board.MoveShips();
            board.MoveCarts();
            board.HasAddedACart();
            board.HasAddedAShip();
            board.KeepScore();
            board.AdjustAmountOfCarts();
            timer.Interval = board.GetTimeInterval();
            this.Render();
        }

        public void Render()
        {
            // Render het board
            ObserverList.NotifyObservers(
                new GameData
                {
                    Game = board.GetGameBoard()
                });
        }

        public void ResetInterval()
        {
            /* Logica voor het resetten van de timer */
            timer.Interval = 1000;
        }

        public IDisposable Subscribe(IObserver<GameData> observer)
        {
            ObserverList.Add(observer);
            return ObserverList;
        }
    }
}