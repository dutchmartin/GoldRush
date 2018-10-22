using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldRush.View
{
    sealed class ViewStringsFactory
    {
        // Create a singleton using the .net Lazy object.
        private static readonly Lazy<ViewStringsFactory> lazy =
        new Lazy<ViewStringsFactory>(() => new ViewStringsFactory());

        public static ViewStringsFactory Instance { get { return lazy.Value; } }

        public char GetDisplayChar(HasNext Item)
        {
            switch(Item)
            {
                case Track track:
                    // Print the track
                    if (track.Direction != Direction.NONE)
                    {
                        if (track.Occupant == null)
                        {
                            return (char)track.Direction;
                        }
                        return '\x00D7';
                    }
                    // Get the chars of special items.
                    return GetDisplayItem(track);
                case WaterQuay waterQuay:
                    return 'H';
                case WaterLink waterLink:
                    return '~';
                default:
                    return ' ';
            }
        }
        private char GetDisplayItem(Track track)
        {
            switch (track)
            {
                case Turnout turnout:
                    return (turnout.isGoingUp) ? '/' : '\\' ;
                case Yard yard:
                    return '\x00AB';// '۝';
                case Hangar hangar:
                    return 'Ξ';
                default:
                    return ' ';
            }
        }
        public string GetDisplayLine(HasNext[] items)
        {
            String DisplayLine = "";
            foreach (HasNext item in items)
            {
                DisplayLine += this.GetDisplayChar(item);
            }
            return DisplayLine;
        }
        public string[] GetDisplayLines(HasNext[][] itemMatrix)
        {
            string[] DisplayLines = new string[itemMatrix.Length];
            for (int i = 0; i < itemMatrix.Length; i++)
            {
                DisplayLines[i] = GetDisplayLine(itemMatrix[i]);
            }
            return DisplayLines;
        }
    }
}
