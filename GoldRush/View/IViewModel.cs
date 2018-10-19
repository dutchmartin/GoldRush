using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldRush.View
{
    interface IViewModel<V>
    {
        V View { get; }
    }
}
