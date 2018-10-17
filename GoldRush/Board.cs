using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldRush
{
    public class Board
    {
        private Random random;
        public int Score { get; private set; }
        public River river { get; set; }
        public List<Ship> Ships { get; private set; }

        public Track TrackEnd { get; private set; }
        public List<Hangar> Hangars { get; private set; }
        public List<Cart> Carts { get; private set; }
        public HashSet<Turnout> Turnouts { get; private set; }

        public Board(int score, Track TrackEnd, List<Hangar> hangars, HashSet<Turnout> turnouts)
        {
            random = new Random();
            Score = score;
            TrackEnd = TrackEnd;
            Carts = new List<Cart>();
            Hangars = hangars;
            Turnouts = turnouts;
            river = new River();
            river.Occupant = new Ship(river);
        }

        public bool AddCarts(int amount)
        {
            if(amount > Hangars.Count)
            {
                return false;
            }
            Hangar ChosenHangar;
            Cart AddedCart = null;
            for(int count = 0; count < amount; count++)
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
        public bool AddShip()
        {
            if(river.Occupant != null)
            {
                return false;
            }
            if(random.Next(1, 10) != 1)
            {
                return false;
            }
            river.Occupant = new Ship(river);
            return true;
        }
        public void MoveCarts()
        {
            Carts.ForEach(c => c.Move());
        }
        public void MoveShips()
        {
            Ships.ForEach(s => s.Move());
        }
    }
}
