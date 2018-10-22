using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Turnout1To2:Turnout
    {
        /* Voor de duidelijkheid:
        Omdat 1to2 één enkele previous heeft kan deze ook meteen meegegeven worden in de constructor
        Dit maakt het onderscheid tussen 1to2 en 2to1 duidelijker
         */

        public override void ChangeDirection()
        {
            if(Occupant !=null)
            {
                return;
            }
            if(isGoingUp)
            {
                isGoingUp = false;
                Next = optionDown;
                optionUp.Next = null;
            }
            else
            {
                isGoingUp = true;
                Next = optionUp;
                optionDown.Next = null;
            }
        }
    }
}