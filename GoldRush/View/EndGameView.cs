using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldRush.View
{
    class EndGameView : IRenderable
    {
        public int Score { get;set;}
        public void Render()
        {
            Console.Clear();
            Console.Write(
                "####################\n" +
                " The game has ended.\n" +
                " Your score was: {0}",
                Score
                );
        }
    }
}
