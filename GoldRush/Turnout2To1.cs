using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Turnout2To1:Turnout
    {
        public Turnout2To1(bool isGoingUp)
        {
            this.isGoingUp = isGoingUp;
        }
    }
}