using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Track
    {
        public TrackLink First;

        public Track()
        {
            First = new TrackLink();
        }

        public Stack<Cart> createCartsQueue()
        {
             /* NIEUWE GEDACHTEGANG
             Je loopt vanaf het begin over de tracks heen A B en C. Dan maak je van alle wagentjes tot aan een next is null een queue
             Deze queue werk je daarna af. Dan hoeven karretjes alleen nog maar te checken of location.next leeg is of niet,
             Want dan heb je meteen rekening gehouden met het probleem van rijd volgorde. Alle wagentjes die al zijn bewogen staan 
             voor wagens die nog moeten */
            Stack<Cart> carts = new Stack<Cart>();
            TrackLink current = First;
            while(current.Next != null)
            {
                if(current.occupant != null)
                {
                    carts.Push(current.occupant);
                }
                current = (TrackLink)current.Next;
            }
            return carts;
        }
    }
    
}