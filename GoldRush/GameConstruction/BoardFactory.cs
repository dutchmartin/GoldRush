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
            AssembleLinks( matrix );
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

        struct Location
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
            foreach(Location HangarLocation in locations)
            {

            }
        }

        private Location NextLink(Object[][] matrix, Location current)
        {
            return new Location();
        }

        private object getObjectFromLocation(Object[][] matrix, Location loc)
        {
            if (loc.x >= matrix.Length || loc.y >= matrix.First().Length)
            {
                throw new ArgumentOutOfRangeException("Could not fetch from matrix[{0}][{1}] with x " + loc.x + " y " + loc.y, matrix.Length, matrix.First().Length.ToString());
            }
            return matrix[loc.y][loc.x];
        }
    }
}

