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
        private bool isRunning;
        public Board board { get; set; }
        public InputController InputController { get; set; } = new InputController();
        private Timer timer;
        private Boolean isGameEnded;
        private View.ObserverList<IObserver<GameData>, GameData> ObserverList = new View.ObserverList<IObserver<GameData>, GameData>();

        public void Play()
        {
            isGameEnded = false;
            BoardBuilder builder = new BoardBuilder();
            board = builder.BuildBoard();

            this.timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
            isRunning = true;
            StartInputPeriod();
        }
        public void StartInputPeriod()
        {
            Render();
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();
                ChangeTurnoutOrientation(key.KeyChar);
                Render();
            }
            while (isRunning && !isGameEnded);
        }

        public void ChangeTurnoutOrientation(char c)
        {
            board.ToggleTurnout(c);
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            isRunning = false;
            Tick();
            isRunning = true;
            StartInputPeriod();
        }

        public void Tick()
        {
            //Tel het aantal intervallen met elkaar op en verklein het interval daarmee
            board.MoveShips();
            board.removeTrackEndCart();
            try
            {
                board.MoveCarts();
            }
            catch (Exception e)
            {
                isGameEnded = true;
                timer.Dispose();
                Render();
                return;
            }

            board.HasAddedACart();
            board.HasAddedAShip();
            board.KeepScore();
            board.AdjustAmountOfCarts();
            //timer.Interval = board.GetTimeInterval();
        }

        public void Render()
        {
            // Render het board
            ObserverList.NotifyObservers(
                new GameData
                {
                    Game = board.GetGameBoard(),
                    IsGameEnded = isGameEnded,
                    score = board.Score
                });
        }

        public IDisposable Subscribe(IObserver<GameData> observer)
        {
            ObserverList.Add(observer);
            return ObserverList;
        }
    }
}