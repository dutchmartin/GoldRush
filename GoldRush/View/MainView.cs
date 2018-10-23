using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldRush.View
{
    class MainView : IRenderable
    {
        public string[] Board { get; set; }
        public int score;
        public void Render()
        {
            // TODO: modify the displaybuffer instead of rewriting everything.
            Console.Clear();
            DrawHeader();
            DrawBoard();
            DrawFooter();
        }

        private void DrawHeader()
        {
            // TODO: Can be refactored to a file read.
            Console.Write(
               "###################\n" +
               "#    Gold Rush    #\n" +
               "###################\n"
               );
        }

        private void DrawBoard()
        {
            foreach (var item in Board)
            {
                Console.WriteLine(item);
            }
        }
        private void DrawFooter()
        {
            // TODO: Can be refactored to a file read.
            Console.Write(
                "##### Score " + score + " #####\n"+
                "###################\n" +
                " Use Q W E R T to\n" +
                " Change the carts path\n"
                
                );
        }
    }
}
