using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public class Hangar : Track
    {

        public Cart AddCart()
        {
            /* Eerst checken of er al een cart op de eerste plek staat van deze hangar
            Zo niet dan kan er een toegevoegd worden.
            Als dit wel het geval is returnt deze functie false */
            if(this.Occupant != null)
            {
                return null;
            }
            Cart newCart  = new Cart();
            track.First.occupant = newCart;
            return newCart;
        }

        public void moveCarts()
        {
            /* Deze functie begint bij de FIRST van het track van de hangar en gaat vervolgens het hele track af
            totdat er geen tracklink meer is, wat dus kan betekenen dat het aan het einde van het spel is, of dat een TURNOUT van
            richting is verandert waardoor het track van deze hangar stopt
            Bij het afgaan van het track word iedere CART op een stack gegooid omdat ze vervolgens in omgekeerde volgorde moeten gaan bewegen om onbedoelde collision te voorkomen */
            Stack<Cart> carts = track.createCartsQueue();
            while(carts.Count > 0)
            {
                carts.Pop().Move();
            }
        }
    }
}