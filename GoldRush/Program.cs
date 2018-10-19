using GoldRush.View;

namespace GoldRush
{
    class Program
{
        static void Main(string[] args)
        {
            MainViewViewModel view = new MainViewViewModel();
            Game game = new Game();
            game.Subscribe(view);
        }
    }
}
