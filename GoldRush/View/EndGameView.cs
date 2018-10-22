using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldRush.View
{
    class EndGameView : IRenderable
    {
        public void Render()
        {
            Console.Clear();
            Console.Write(
                "####################\n" +
                " The game has ended.\n"
                );
        }
    }
}
