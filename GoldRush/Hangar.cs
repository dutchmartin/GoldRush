using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Hangar
    {
        public Track track;

        public Hangar()
        {
            track = new Track();
        }

        public bool AddCart()
        {
            if(this.track.First.occupant != null)
            {
                return false;
            }
            Cart newCart  = new Cart(track.First);
            track.First.occupant = newCart;
            return true;
        }

        public void moveCarts()
        {
            Stack<Cart> carts = track.createCartsQueue();
            while(carts.Count > 0)
            {
                carts.Pop().Move();
            }
        }
    }
}