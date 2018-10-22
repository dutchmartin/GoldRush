using GoldRush.View;
using System;

namespace GoldRush
{
    class Program
{
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            MainViewViewModel view = new MainViewViewModel();
            Game game = new Game();
            game.Subscribe(view);
            game.Play();
        }
    }
}
