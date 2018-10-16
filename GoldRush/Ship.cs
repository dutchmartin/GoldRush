using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Ship : MoveableObject
    {
        public int load{get; protected set;}
        public TrackLink location;
        // private bool isDocked;

        public Ship()
        {
            load = 0;
        }
        public override bool canMove()
        {
            if(location is Quay)
            {
                if(location.occupant != null)
                {
                    load++;
                    location.occupant.isLoaded = false;
                }
            }
            else
            {
                return true;
            }

            if(load == 8)
            {
                return true;
            }
            return false;
        }

        public override void Move()
        {
            if(canMove())
            {
                this.location = location.Next;
            }
        }
    }
}