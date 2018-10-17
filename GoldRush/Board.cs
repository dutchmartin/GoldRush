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
        public WaterQuay quay { get; set; }
        public int Score { get; private set; }
        public River FirstRiver { get; set; }

        public Track TrackEnd { get; private set; }
        public List<Ship> Ships { get; private set; }
        public List<Hangar> Hangars { get; private set; }
        public List<Cart> Carts { get; private set; }
        public HashSet<Turnout> Turnouts { get; private set; }

        public Board(int score, Track TrackEnd, List<Hangar> hangars, HashSet<Turnout> turnouts)
        {
            Score = score;
            TrackEnd = TrackEnd;
            Hangars = hangars;
            Turnouts = turnouts;
            random = new Random();
            Carts = new List<Cart>();
            Ships = new List<Ship>();
            FirstRiver = new River();
            FirstRiver.Occupant = new Ship(FirstRiver);
            Ships.Add(FirstRiver.Occupant);
        }

        public bool HasAddedACart(int amount)
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
            Ships.ForEach(s => s.Move());
        }

        public void KeepScore()
        {
            if(quay.Occupant.isLoaded)
            {
                Score += 10;
            }
            if(!quay.track.Occupant.isLoaded)
            {
                Score += 1;
            }
        }
    }
}
