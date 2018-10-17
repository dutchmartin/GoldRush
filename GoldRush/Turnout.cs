using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public abstract class Turnout: Track
    {
        /* een turnout kan een ingang en EFFECTIEF 1 uitgang hebben, namelijk de uitgang waar hij WEL aan doorgeeft
        Daarom heb ik de container incoming gemaakt.
        MAAR omdat er al een outgoing bestaat, namelijk de "Next" overgeorven van TrackLink hoeft die er niet bij */
        public bool isGoingUp {get; protected set;}
        public Track previous {get; protected set;}
        public Track optionUp {get; protected set;}
        public Track optionDown{get; protected set;}
    }
}