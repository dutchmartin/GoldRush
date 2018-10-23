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
        public WaterLink FirstRiver { get; set; }

        public Track TrackEnd { get; private set; }
        public List<Ship> Ships { get; private set; }
        public List<Hangar> Hangars { get; private set; }
        public List<Cart> Carts { get; private set; }
        public Dictionary<char, Turnout> Turnouts { get; private set; }

        private HasNext[][] _GameBoard;

        public Board(int score, Track TrackEnd, List<Hangar> hangars, Dictionary<char, Turnout> turnouts, WaterQuay quay, HasNext[][] GameBoard, WaterLink first)
        {
            Score = score;
            this.quay = quay;
            this.TrackEnd = TrackEnd;
            Hangars = hangars;
            Turnouts = turnouts;
            random = new Random();
            Carts = new List<Cart>();
            Ships = new List<Ship>();
            FirstRiver = first;
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
                    ChosenHangar = Hangars[random.Next(0, 3)];
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
            if(random.Next(1, 2) ==1)
            {
                Ship newShip = new Ship(FirstRiver);
                FirstRiver.Occupant = newShip;
                Ships.Add(newShip);
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
            if (Ships.Count > 0)
            {
                Ships.ForEach(s => s.Move());
                Ships.RemoveAll(s => s.location == null);
            }
        }

        public void removeTrackEndCart()
        {
            if(TrackEnd.Occupant != null)
            {
                Cart removeableCart = TrackEnd.Occupant;
                Carts.Remove(removeableCart);
                TrackEnd.Occupant = null;
            }
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
            if (quay.track.Occupant == null)
            {
                return;
            }
            if(!(quay.track.Occupant.isLoaded))
            {
                Score += 1;
            }
        }

        public double GetTimeInterval()
        {
            double result = 2000;
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

        public void ExchangeLoad()
        {
            if (quay.Occupant == null || quay.track.Occupant == null)
                return;
            Ship ship = quay.Occupant;
            Cart cart = quay.track.Occupant;
            ship.ExchangeLoad(cart);
        }
    }
}
