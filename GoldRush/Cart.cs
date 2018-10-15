using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Cart : MoveableObject
    {
        public bool isLoaded {get; protected set;}
        TrackLink location;

        public Cart(TrackLink placement)
        {
            isLoaded = true;
            location = placement;
        }

        public override void Move()
        {
            if(location is Quay)
                isLoaded = false;

            if(canMove())
            {
                location.occupant = null;
                location.Next.occupant = this;
                location = location.Next;
            }
            else
            {
                Console.WriteLine("Crash");
                /* TODO: CRASH!!!!!!! */
            }
        }
        public override bool canMove()
        {
             if(location.Next == null)
             {
                 return false;
             }

             if(location.Next.occupant == null)
             {
                 return true;
             }

             return false;
        }
    }
}