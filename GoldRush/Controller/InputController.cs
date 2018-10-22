using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldRush.Controller
{
    public class InputController
    {
        public char GetKeyInput()
        {
            return Console.ReadKey().KeyChar;
        }
    }
}
