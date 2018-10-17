using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldRush
{
    public class InputHandler
    {
        public ConsoleKey GetKeyInput()
        {
            ConsoleKey input;
            do
            {
                input = Console.ReadKey().Key;
            }
            while ( ! IsCorrectKey(input));
            return input;
        }
        private Boolean IsCorrectKey(ConsoleKey key)
        {
            var KeyCode = (int) key;
            var min = 49;
            var max = 53;
            return TestRange(KeyCode, min, max);
        }
        private bool TestRange(int numberToCheck, int bottom, int top)
        {
            return (numberToCheck >= bottom && numberToCheck <= top);
        }
    }
}
