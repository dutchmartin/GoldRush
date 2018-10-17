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
            optionDown = new Track();
            optionUp = new Track();
            if(isGoingUp)
            {
                Next = optionUp;
            }
            else
            {
                Next = optionDown;
            }
            //TODO set next!
        }

        public void ChangeDirection()
        {
            if(Occupant !=null)
            {
                return;
            }
            if(isGoingUp)
            {
                isGoingUp = false;
                Next = optionDown;
            }
            else
            {
                isGoingUp = true;
                Next = optionUp;
            }
        }
    }
}