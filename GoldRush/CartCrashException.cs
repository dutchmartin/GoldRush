using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldRush
{
    class CartCrashException : Exception
    {
        public String GameOverMessage;

        public CartCrashException()
        {
            GameOverMessage = "A cart has crashed, you are gameover";
        }
    }
}
