using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GoldRush.GameConstruction
{
    sealed class HasNext2DArrayFactory
    {
        // Create a singleton using the .net Lazy object.
        private static readonly Lazy<HasNext2DArrayFactory> lazy =
        new Lazy<HasNext2DArrayFactory>(() => new HasNext2DArrayFactory());

        public static HasNext2DArrayFactory Instance { get { return lazy.Value; } }

        public HasNext[][] GetHasNext2DArray()
        {
            var level = GetLevelMatrix();
            HasNext[][] LevelObjectMap = new HasNext[level.Length][];
            var factory = HasNextFactory.Instance;
            for (int i = 0; i < level.Length; i++)
            {
                LevelObjectMap[i] = level[i]
                    .Select(LevelObject => factory.GetHasNext(LevelObject))
                    .ToArray();
            }
            return LevelObjectMap;
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
    }
}
