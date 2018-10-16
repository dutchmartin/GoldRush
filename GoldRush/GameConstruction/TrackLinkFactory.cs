using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldRush
{
    public sealed class TrackLinkFactory
    {
        // Create a singleton using the .net Lazy object.
        private static readonly Lazy<TrackLinkFactory> lazy =
        new Lazy<TrackLinkFactory>(() => new TrackLinkFactory());

        public static TrackLinkFactory Instance { get { return lazy.Value; } }

        public Object GetTrackLink(char linkChar)
        {
            switch (linkChar)
            {
                case 'Ξ':
                    return new Hangar();
                //case 'ա':
                //    return new Cart();
                case '֍':
                    return new Quay();
                case '۝':
                    return new Yard();
                case 'ᚓ':
                    return new TrackLink();
                case '᚜':
                    return new Turnout1to2(null, false);
                case '᚛':
                    return new Turnout2To1(false, null, null );
                default:
                    return new TrackLink();
            }
        }
    }
}