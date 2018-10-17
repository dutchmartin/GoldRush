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
            Cart newCart  = new Cart(this);
            this.Occupant = newCart;
            return newCart;
        }
    }
}