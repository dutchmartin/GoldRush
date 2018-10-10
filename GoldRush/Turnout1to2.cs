using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Turnout1to2:Turnout
    {
        public Turnout1to2(Turnout entry, bool isGoingUp){
            this.isGoingUp = isGoingUp;
        }
    }
}