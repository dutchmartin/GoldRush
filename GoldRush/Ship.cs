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
               Cart Occupant = ((WaterQuay)location).track.Occupant;
               if(Occupant != null)
               {
                    ExchangeLoad(Occupant);
               }
            }
            else
            {
                WaterLink nextWaterLink = (WaterLink)location.Next;
                if(nextWaterLink == null)
                {
                    //TODO remove ship
                    return false;
                }
                if(nextWaterLink.Occupant == null)
                {  
                    return true;
                }
               return false;
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
            }
        }
    }
}