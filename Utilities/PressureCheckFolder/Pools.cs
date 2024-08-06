#nullable enable
using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using System.Linq;

namespace LuneLib.Utilities.PressureCheckFolder
{
    public class Pools
    {
        List<Pool> pools;

        public Pools()
        {
            this.pools = new List<Pool>();
        }

        public static Pools CreatePools()
        {
            var pools = new Pools();
            HashSet<Point> visited = new HashSet<Point>();

            for (int y = 0; y < Main.tile.Height; y++)
            {
                for (int x = 0; x < Main.tile.Width; x++)
                {
                    if(x == 3740 && y == 549) System.Diagnostics.Debugger.Break();

                    if (visited.Contains(new Point(x, y))) { continue; }

                    var tile = Main.tile[x, y];
                    if (IsWaterTile(tile))
                    {
                        var floodedPoints = Floodfill(pools, new Point(x, y));

                        foreach (var p in floodedPoints) visited.Add(p);
                    }
                }
            }

            return pools;
        }

        private static bool IsWaterTile(Tile tile)
        {
            return tile.LiquidAmount == 255 && tile.LiquidType == LiquidID.Water;
        }

        private static IEnumerable<Point> Floodfill(Pools pools, Point startPoint)
        {
            var pointsFilled = new HashSet<Point>();

            var visited = new HashSet<Point>();
            var toVisit = new Queue<Point>();

            toVisit.Enqueue(startPoint);

            while (toVisit.Count > 0)
            {
                var currentPoint = toVisit.Dequeue();

                visited.Add(currentPoint);

                var currentTile = Main.tile[currentPoint];
                if (IsWaterTile(currentTile))
                {
                    pointsFilled.Add(currentPoint);

                    var leftOf = new Point(currentPoint.X - 1, currentPoint.Y);
                    if (currentPoint.X > 0 && !visited.Contains(leftOf) && !toVisit.Contains(leftOf))
                        toVisit.Enqueue(leftOf);

                    var rightOf = new Point(currentPoint.X + 1, currentPoint.Y);
                    if (currentPoint.X < Main.tile.Width - 1 && !visited.Contains(rightOf) && !toVisit.Contains(rightOf))
                        toVisit.Enqueue(rightOf);

                    var above = new Point(currentPoint.X, currentPoint.Y - 1);
                    if (currentPoint.Y > 0 && !visited.Contains(above) && !toVisit.Contains(above))
                        toVisit.Enqueue(above);

                    var below = new Point(currentPoint.X, currentPoint.Y + 1);
                    if (currentPoint.Y < Main.tile.Height - 1 && !visited.Contains(below) && !toVisit.Contains(below))
                        toVisit.Enqueue(below);
                }
            }

            var newPool = new Pool();
            newPool.AddPoints(pointsFilled);
            if(pointsFilled.Contains(new Point(3740, 549))) System.Diagnostics.Debugger.Break();
            pools.pools.Add(newPool);

            return pointsFilled;
        }

        public Pool? FindPool(Vector2 position)
        {
            foreach (Pool pool in pools)
            {
                if (pool.IsIn(position)) return pool;
            }

            return null;
        }
    }
}
