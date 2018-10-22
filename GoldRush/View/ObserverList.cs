using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldRush.View
{
    public sealed class ObserverList<T, G> : IDisposable where T : IObserver<G>
    {
        private List<T> _Observers { get; set; }

        public ObserverList()
        {
            _Observers = new List<T>();
        }
        public void Dispose()
        {
           _Observers.RemoveAll(item => true);
        }
        public void Add(T item)
        {
            _Observers.Add(item);
        }

        public void NotifyObservers(G NewData)
        {
            _Observers.ForEach(item => item.OnNext(NewData));
        }
    }
}
