using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Cart : MoveableObject
    {
        public bool hasMoved;
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
                TrackLink nextLocation = (TrackLink)location.Next;
                if (nextLocation == null)
                {
                    return;
                }
                location.occupant = null;
                nextLocation.occupant = this;
                location = nextLocation;
            }

            hasMoved = true;
        }
        public override bool canMove()
        {
            TrackLink nextLocation = (TrackLink)location.Next;
            if(nextLocation==null)
            {
                return false;
            }
            Cart nextCart = nextLocation.occupant;
            if(nextCart == null)
            {
                return true;
            }
            if(location is Yard)
            {
                return false;
            }
            if(!nextCart.canMove())
            {
                throw new CartCrashException();
            }
            nextCart.Move();
            return true;
        }
    }
}