﻿using System;
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
        public override bool collides()
        {
            if(location is WaterQuay)
            {
               Cart occupant = ((WaterQuay)location).track.occupant;
               if(occupant != null)
               {
                    if(occupant.isLoaded)
                    {
                        occupant.isLoaded = false;
                        load++;
                    }
               }
            }
            else
            {
                WaterLink nextWaterLink = (WaterLink)location.Next;
                if(nextWaterLink.ship == null)
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
            if(collides())
            {
                location.ship = null;
                this.location = (WaterLink) location.Next;
                location.ship = this;
            }
        }
    }
}