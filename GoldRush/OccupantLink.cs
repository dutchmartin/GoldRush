using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public interface OccupantLink<T> : HasNext
    {
        T Occupant { get; set; }
    }
}