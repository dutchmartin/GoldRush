using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Ship : MoveableObject
    {
        public int load{get; protected set;}
        public WaterLink location;
        // private bool isDocked;

        public Ship(WaterLink locate)
        {
            location = locate;
            load = 0;
        }
        public override bool canMove()
        {
            if(location is WaterQuay)
            {
                if (isLoaded)
                {
                    return true;
                }
                return false;
            }
            else
            {
                WaterLink nextWaterLink = (WaterLink)location.Next;
                if(nextWaterLink == null)
                {
                    location.Occupant = null;
                    this.location = null;
                    return false;
                }
                if(nextWaterLink.Occupant == null)
                {  
                    return true;
                }
               return false;
            }
        }

        public override void Move()
        {
            if(canMove())
            {
                location.Occupant = null;
                this.location = (WaterLink) location.Next;
                location.Occupant = this;
            }
        }

        public void ExchangeLoad(Cart Occupant)
        {
            if(Occupant.isLoaded)
            {
                Occupant.isLoaded = false;
                load++;
                if (load == 8)
                    isLoaded = true;
            }
        }
    }
}