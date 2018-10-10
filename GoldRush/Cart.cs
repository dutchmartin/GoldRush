using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Cart : MoveableObject
    {
        bool isLoaded;
        TrackLink location;

        public Cart(TrackLink location)
        {
            isLoaded = true;
            this.location = location;
        }

        public override void Move()
        {
            if(location is Quay)
                isLoaded = false;

            if(allowMovement())
            {
                location.occupant = null;
                location.Next.occupant = this;
                location = location.Next;
            }
            else
            {
                /* TODO: CRASH!!!!!!! */
            }
        }
        public bool allowMovement()
        {
             /* NIEUWE GEDACHTEGANG
             Je loopt vanaf het begin over de tracks heen A B en C. Dan maak je van alle wagentjes tot aan een next is null een queue
             Deze queue werk je daarna af. Dan hoeven karretjes alleen nog maar te checken of location.next leeg is of niet,
             Want dan heb je meteen rekening gehouden met het probleem van rijd volgorde. Alle wagentjes die al zijn bewogen staan 
             voor wagens die nog moeten */
             if(location.Next == null)
             {
                 return false;
             }

             if(location.Next.occupant == null)
             {
                 return true;
             }

             return false;
        }
    }
}