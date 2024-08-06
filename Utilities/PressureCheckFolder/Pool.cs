using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace LuneWOL.PressureCheckFolder
{
    public class Pool
    {
        public int SurfaceY;

        private Dictionary<int, (int leftX, int rightX)> Bounds;

        public Pool()
        {
            Bounds = new Dictionary<int, (int, int)>();
        }

        public void AddPoints(IEnumerable<Point> floodFilledPositions)
        {
            int minY = int.MaxValue;

            // For each y, check minX = left and maxX = right. Add to Bounds.
            foreach (var point in floodFilledPositions)
            {
                if(point.Y < minY) { minY = point.Y; }

                if (!Bounds.ContainsKey(point.Y))
                {
                    var allOnY = floodFilledPositions.Where(p => p.Y == point.Y).Select(c => c.X);

                    Bounds[point.Y] = (allOnY.Min(), allOnY.Max());
                }
            }

            SurfaceY = minY;
        }

        internal bool IsIn(Vector2 position)
        {
            var tilePosition = position.ToTileCoordinates();
            
            if (!Bounds.TryGetValue(tilePosition.Y, out var bounds))
                return false;

            return tilePosition.X >= bounds.leftX && tilePosition.X <= bounds.rightX;
        }
    }
}
