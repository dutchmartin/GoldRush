using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Cart : MoveableObject
    {
        public bool isLoaded {get; set;}
        bool hasMoved;
        TrackLink location;

        public Cart(TrackLink placement)
        {
            hasMoved = false;
            isLoaded = true;
            location = placement;
            placement.occupant = this;
        }

        public override void Move()
        {
            if(canMove())
            {
                location.occupant = null;
                TrackLink nextLocation = (TrackLink)location.Next;
                nextLocation.occupant = this;
                this.location = nextLocation;
                hasMoved = true;
            }
            else
            {
                Console.WriteLine("Crash");
                /* TODO: CRASH!!!!!!! */
            }
        }
        public override bool canMove()
        {
            if(hasMoved)
            {
                return false;
            }
            TrackLink nextLocation = (TrackLink)location.Next;
            if (nextLocation == null)
             {
                 return false;
             }

             Cart nextCart = nextLocation.occupant;
             if(nextCart != null)
             {
                 nextCart.Move();
             }


             return false;
        }
    }
}