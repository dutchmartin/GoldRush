using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public abstract class MoveableObject
    {
        bool isLoaded;
        Track location;
        public abstract bool canMove();
        public abstract void Move();
    }
}