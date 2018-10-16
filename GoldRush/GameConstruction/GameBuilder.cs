using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GoldRush.GameConstruction
{
    public sealed class GameBuilder
    {
        // Create a singleton using the .net Lazy object.
        private static readonly Lazy<GameBuilder> lazy =
        new Lazy<GameBuilder>(() => new GameBuilder());

        public static GameBuilder Instance { get { return lazy.Value; } }

        public object BuildGame()
        {
            return null;
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
    }
}

