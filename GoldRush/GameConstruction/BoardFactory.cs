using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace GoldRush
{
    public sealed class BoardFactory
    {
        // Create a singleton using the .net Lazy object.
        private static readonly Lazy<BoardFactory> lazy =
        new Lazy<BoardFactory>(() => new BoardFactory());

        public static BoardFactory Instance { get { return lazy.Value; } }


        public Board GetBoard()
        {
            var matrix = GetLevelObjectMap();
            AssembleLinks(matrix);
            return new Board
                (
                0,
                null,
                GetUpperTrackLink(),
                GetHangars(matrix),
                null
                );
        }

        private string GetLevel()
        {
            // Return hardcoded file after the line endings are normalised.
            return Regex
                .Replace(Properties.Resources.Level, @"\r\n|\n\r|\n|\r", "\n");
        }

        private char[][] GetLevelMatrix()
        {
            return GetLevel()
                .Split('\n')
                .Select(line => line.ToCharArray())
                .ToArray();
        }

        private Object[][] GetLevelObjectMap()
        {
            var level = GetLevelMatrix();
            Object[][] LevelObjectMap = new object[level.Length][];
            TrackLinkFactory factory = TrackLinkFactory.Instance;
            for (int i = 0; i < level.Length; i++)
            {
                LevelObjectMap[i] = level[i]
                    .Select(LevelObject => factory.GetTrackLink(LevelObject))
                    .ToArray();
            }
            return LevelObjectMap;
        }

        private List<Location> GetHangarLocations(Object[][] LevelMatrix)
        {
            /*
            List<Hangar> Hangars = new List<Hangar>();
            foreach(var ArrayItem in LevelMatrix)
            {
                ArrayItem
                    .OfType<Hangar>()
                    .ToList()
                    .ForEach(Hangars.Add);
            }
            return Hangars;
            */
            List<Location> locations = new List<Location>();
            for (int i = 0; i < LevelMatrix.Length; i++)
            {
                for (int j = 0; j < LevelMatrix[i].Length; j++)
                {
                    if (LevelMatrix[i][j] is Hangar)
                    {
                        locations.Add(new Location { y = i, x = j });
                    }
                }
            }
            return locations;
        }
        private List<Hangar> GetHangars(Object[][] matrix)
        {
            return GetHangarLocations(matrix)
                .Select(item => matrix[item.y][item.x])
                .Cast<Hangar>()
                .ToList();
        }

        private struct Location
        {
            public int y;
            public int x;
        }


        private TrackLink GetUpperTrackLink()
        {
            return null;
        }

        private void AssembleLinks(Object[][] Matrix)
        {
            var locations = GetHangarLocations(Matrix);
            foreach (Location HangarLocation in locations)
            {
                Location current = HangarLocation;
                // Does not work, hangar is not a track
                TrackLink Last = (TrackLink) getObjectFromLocation(Matrix, HangarLocation);
                while (true)
                {
                    // Find the next link if it exists.
                    TrackLink NextTrackLink;
                    current = NextLink(Matrix, current, out NextTrackLink);
                    if (current.x == -1)
                        break;

                }
            }
        }

        // Bon appetit spagetti!
        private Location NextLink(Object[][] matrix, Location current, out TrackLink NextTrackLink)
        {
            if (getObjectFromLocation(matrix, RightLocation(current)) is TrackLink)
            {
                NextTrackLink = getObjectFromLocation(matrix, RightLocation(current)) as TrackLink;
                return RightLocation(current);
            }
            else if (getObjectFromLocation(matrix, UnderLocation(current)) is TrackLink)
            {
                NextTrackLink = getObjectFromLocation(matrix, UnderLocation(current)) as TrackLink;
                return UnderLocation(current);
            }
            else if (getObjectFromLocation(matrix, LeftLocation(current)) is TrackLink)
            {
                NextTrackLink = getObjectFromLocation(matrix, LeftLocation(current)) as TrackLink;
                return LeftLocation(current);
            }
            else if (getObjectFromLocation(matrix, AboveLocation(current)) is TrackLink)
            {
                NextTrackLink = getObjectFromLocation(matrix, AboveLocation(current)) as TrackLink;
                return AboveLocation(current);
            }
            else
            {
                NextTrackLink = null;
                return new Location { x = -1 };
            }  
        }
        private Location RightLocation(Location loc) 
            => 
            new Location
            {
                y = loc.y,
                x = loc.x + 1
            };
        private Location UnderLocation(Location loc)
            =>
            new Location
             {
                 y = loc.y + 1,
                 x = loc.x,
             };
        private Location LeftLocation(Location loc)
            =>
            new Location
            {
                y = loc.y,
                x = loc.x -1,
            };
        private Location AboveLocation(Location loc)
            =>
            new Location
             {
                 y = loc.y - 1,
                 x = loc.x,
             };

        private object getObjectFromLocation(Object[][] matrix, Location loc)
        {
            if (loc.x >= matrix.Length || loc.y >= matrix.First().Length || loc.x < 0 || loc.x < 0)
            {
                // Use nullObject pattern;
                return new object();
                //throw new ArgumentOutOfRangeException("Could not fetch from matrix[{0}][{1}] with x " + loc.x + " y " + loc.y, matrix.Length, matrix.First().Length.ToString());
            }
            return matrix[loc.y][loc.x];
        }
    }
}

