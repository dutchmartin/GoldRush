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
        public Turnout2To1(bool isGoingUp, TrackLink optionUp, TrackLink optionDown)
        {
            this.isGoingUp = isGoingUp;
            this.optionUp = optionUp;
            this.optionDown = optionDown;
            this.Next = new TrackLink();
        }

        public void ChangeDirection()
        {
            if(isGoingUp)
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