using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Cart : MoveableObject
    {
        public bool isLoaded {get; set;}
        TrackLink location;

        public Cart(TrackLink placement)
        {
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
            }
            else
            {
                Console.WriteLine("Crash");
                /* TODO: CRASH!!!!!!! */
            }
        }
        public override bool canMove()
        {
            TrackLink nextLocation = (TrackLink)location.Next;
            if (nextLocation == null)
             {
                 return false;
             }

             if(nextLocation.occupant == null)
             {
                 return true;
             }

             return false;
        }
    }
}