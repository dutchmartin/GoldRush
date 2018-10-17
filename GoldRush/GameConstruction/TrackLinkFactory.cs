using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public sealed class HasNextFactory
    {
        // Create a singleton using the .net Lazy object.
        private static readonly Lazy<HasNextFactory> lazy =
        new Lazy<HasNextFactory>(() => new HasNextFactory());

        public static HasNextFactory Instance { get { return lazy.Value; } }

        public HasNext GetHasNext(char linkChar)
        {
            switch (linkChar)
            {
                case 'Ξ':
                    return new Hangar();
                //case 'ա':
                //    return new Cart();
                case '֍':
                   return new WaterQuay( null );
                case '۝':
                    return new Yard();
                case '>':
                    return new Track(Direction.RIGHT);
                case '^':
                    return new Track(Direction.UP);
                case '<':
                    return new Track(Direction.LEFT);
                case '⌄':
                    return new Track(Direction.DOWN);
                case 's':
                case '᚜':
                    return new Turnout1to2(null, false);
                case 'S':
                case '᚛':
                    return new Turnout2To1(false, null, null);
                case '~':
                    return new WaterLink();
                default:
                    return null;
            }
        }
    }
}