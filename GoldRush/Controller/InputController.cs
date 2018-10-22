using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldRush.Controller
{
    public class InputController
    {
        public bool GetKeyInput(out char input)
        {
            if (Console.KeyAvailable)
            {
                input = Console.ReadKey().KeyChar;
                return true;
            }
            input = ' ';
            return false;
        }
    }
}
