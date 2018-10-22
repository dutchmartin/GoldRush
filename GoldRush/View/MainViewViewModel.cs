using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldRush.View
{
    class MainViewViewModel : IViewModel<MainView>, IObserver<GameData>
    {
        public MainView View { get; private set; } = new MainView();
        private ViewStringsFactory _viewStringsFactory = ViewStringsFactory.Instance;

        public void OnCompleted()
        {
            // Wait for GC.
        }

        public void OnError(Exception error)
        {
            Console.WriteLine(error);
        }

        public void OnNext(GameData value)
        {
            View.Board = _viewStringsFactory.GetDisplayLines(value.Game);
            View.Render();
        }
    }
}
