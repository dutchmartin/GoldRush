using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Ship : MoveableObject
    {
        public int load{get; protected set;}
        private bool isDocked;

        public Ship()
        {
            load = 0;
        }
        public override bool canMove()
        {
            if(!isDocked)
                return true;

            if(load == 8)
                return true;

            return false;
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}