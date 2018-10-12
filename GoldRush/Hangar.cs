using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Hangar
    {
        private Track _track;

        public Hangar()
        {
            _track = new Track();
        }

        public void AddCart()
        {
            Cart newCart  = new Cart(_track.First);
        }

        public void moveCarts()
        {
            Queue<Cart> carts = _track.createCartsQueue();
            while(carts.Count > 0)
            {
                carts.Dequeue().Move();
            }
        }
    }
}