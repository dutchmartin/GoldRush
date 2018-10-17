using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Cart : MoveableObject
    {
        public bool hasMoved;
        Track location;

        public Cart(Track placement)
        {
            hasMoved = false;
            isLoaded = true;
            location = placement;
            placement.Occupant = this;
        }

        public override void Move()
        {
            if(canMove())
            {
                Track nextLocation = (Track)location.Next;
                if (nextLocation == null)
                {
                    return;
                }
                location.Occupant = null;
                nextLocation.Occupant = this;
                location = nextLocation;
            }

            hasMoved = true;
        }
        public override bool canMove()
        {
            Track nextLocation = (Track)location.Next;
            if(nextLocation==null)
            {
                return false;
            }
            Cart nextCart = nextLocation.Occupant;
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