using GoldRush.GameConstruction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldRush
{
    public class Board
    {
        private int amountOfCarts = 1;
        private Random random;
        public WaterQuay quay { get; set; }
        public int Score { get; private set; }
        public River FirstRiver { get; set; }

        public Track TrackEnd { get; private set; }
        public List<Ship> Ships { get; private set; }
        public List<Hangar> Hangars { get; private set; }
        public List<Cart> Carts { get; private set; }
        public Dictionary<char, Turnout> Turnouts { get; private set; }

        private HasNext[][] _GameBoard;

        public Board(int score, Track TrackEnd, List<Hangar> hangars, Dictionary<char, Turnout> turnouts, WaterQuay quay, HasNext[][] GameBoard)
        {
            Score = score;
            this.quay = quay;
            TrackEnd = TrackEnd;
            Hangars = hangars;
            Turnouts = turnouts;
            random = new Random();
            Carts = new List<Cart>();
            Ships = new List<Ship>();
            FirstRiver = new River();
            FirstRiver.Occupant = new Ship(FirstRiver);
            Ships.Add(FirstRiver.Occupant);
            _GameBoard = GameBoard;
        }

        public bool HasAddedACart()
        {
            if(amountOfCarts > Hangars.Count)
            {
                return false;
            }
            Hangar ChosenHangar;
            Cart AddedCart = null;
            for(int count = 0; count < amountOfCarts; count++)
            {
                while(AddedCart == null)
                {
                    ChosenHangar = Hangars[random.Next(1, Hangars.Count)];
                    AddedCart = ChosenHangar.AddCart();
                }
                Carts.Add(AddedCart);
            }
            return true;
        }
        public bool HasAddedAShip()
        {
            if(FirstRiver.Occupant != null)
            {
                return false;
            }
            if(random.Next(1, 10) ==1)
            {
                FirstRiver.Occupant = new Ship(FirstRiver);
                return true;
            }
            return false;
        }
        public void MoveCarts()
        {
            Carts.ForEach(c => c.Move());
        }
        public void MoveShips()
        {
            if(Ships.Count > 0)
                Ships.ForEach(s => s.Move());
        }

        public void KeepScore()
        {
            if(quay.Occupant == null)
            {
                return;
            }
            if(quay.Occupant.isLoaded)
            {
                Score += 10;
            }
            if(!quay.track.Occupant.isLoaded)
            {
                Score += 1;
            }
        }

        public double GetTimeInterval()
        {
            double result = 5000;
            for(int i = Score%10; i > 0; i--)
            {
                result -= 100;
            }
            return result;
        }

        public void AdjustAmountOfCarts()
        {
            amountOfCarts += Score%50;
            if(amountOfCarts > Hangars.Count)
                amountOfCarts = Hangars.Count;
        }

        public HasNext[][] GetGameBoard()
        {
            return _GameBoard;
        }
        public void ToggleTurnout(Char c)
        {
            if(this.Turnouts.TryGetValue(c, out Turnout t))
            {
                t.ChangeDirection();
            }
        }
    }
}
