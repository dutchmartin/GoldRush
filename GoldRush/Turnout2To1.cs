using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Turnout2To1:Turnout
    {
        /* Omdat tijdens het genereren van de hele track misschien nog niet alle "next" track elementen 
        bekend zijn kun je alleen de startpositie aangeven van dit track. */
        public void ChangeDirection()
        {
            if (Occupant != null)
            {
                return;
            }
            if (isGoingUp)
            {
                isGoingUp = false;
                previous = optionDown;
            }
            else
            {
                isGoingUp = true;
                previous = optionUp;
            }
        }
    }
}