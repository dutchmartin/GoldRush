using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Turnout1to2:Turnout
    {
        /* Voor de duidelijkheid:
        Omdat 1to2 één enkele previous heeft kan deze ook meteen meegegeven worden in de constructor
        Dit maakt het onderscheid tussen 1to2 en 2to1 duidelijker
         */
        public Turnout1to2(Turnout entry, bool isGoingUp){
            this.isGoingUp = isGoingUp;
            previous = entry;
        }

        public void ChangeDirection()
        {
            if(isGoingUp)
            {
                isGoingUp = false;
                Next = optionDown;
            }
            else
            {
                isGoingUp = true;
                Next = optinoUp;
            }
        }
    }
}