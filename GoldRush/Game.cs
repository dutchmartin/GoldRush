﻿using GoldRush.Controller;
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
        private bool isGameEnded;
        private View.ObserverList<IObserver<GameData>, GameData> ObserverList = new View.ObserverList<IObserver<GameData>, GameData>();

        public void Play()
        {
            isGameEnded = false;
            BoardBuilder builder = new BoardBuilder();
            board = builder.BuildBoard();

            this.timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            timer.Elapsed += DecreaseTimerInterval;
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
            board.ExchangeLoad();
            board.KeepScore();
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
            board.AdjustAmountOfCarts();
            timer.Interval = board.GetTimeInterval();
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
        private void DecreaseTimerInterval(Object source, ElapsedEventArgs e)
        {
            var interval = NewTimerMilisecondsTime( this.timer.Interval);
            // Create a minimum.
            if (interval < 50)
                interval = 50;
            this.timer.Interval = this.timer.Interval;
        }
        private double NewTimerMilisecondsTime(double Time)
        {
            const double PowerTo = 13 / 10;
            return 1000 - Math.Ceiling(Math.Pow(Time, PowerTo));
        }
    }
}