using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Cart : MoveableObject
    {
        bool isLoaded;
        TrackLink location;

        public Cart(TrackLink location)
        {
            isLoaded = true;
            this.location = location;
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