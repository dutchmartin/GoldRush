using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Track
    {
        TrackLink First;

        public void addCart()
        {
            Cart newCart = new Cart(First);
        }

        private Queue<Cart> createCartsQueue()
        {
            Queue<Cart> carts = new Queue<Cart>();
            TrackLink current = First;
            while(current.Next != null)
            {
                if(current.occupant != null)
                {
                    carts.Enqueue(current.occupant);
                }
                current = current.Next;
            }
            return carts;
        }

        public void moveCarts()
        {
            Queue<Cart> carts = createCartsQueue();
            while(carts.Count > 0)
            {
                carts.Dequeue().Move();
            }
        }
    }
    
}