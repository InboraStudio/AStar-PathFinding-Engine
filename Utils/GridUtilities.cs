using System;
using System.Collections.Generic;
using AStarPathfindingEngine.Core;

namespace AStarPathfindingEngine.Utils
{
    public class GridUtilities
    {
        // Generate random obstacles
public static void CreateRandomObstacles(Grid grid, int obstacleCount, Random random = null) // added optional Random parameter for better randomness control
        {
            if (random == null)
                random = new Random();

            for (int i = 0; i < obstacleCount; i++) // loop to create obstacles
            {
                int x = random.Next(0, grid.Width);
                int y = random.Next(0, grid.Height);
                grid.SetNodeWalkable(x, y, false);
            }
        }
        public static void CreateWall(Grid grid, int x1, int y1, int x2, int y2)
        {
            int dx = Math.Abs(x2 - x1); // delta x for bresenham Y
            int dy = Math.Abs(y2 - y1); // delta y for bresenham
            int sx = x1 < x2 ? 1 : -1; // step x
            int sy = y1 < y2 ? 1 : -1; // step y
            int err = dx - dy;

            int x = x1, y = y1;

            while (true)
            {
                grid.SetNodeWalkable(x, y, false); // set wall at (x, y) so we can block paths

                if (x == x2 && y == y2)
                    break;

                int e2 = 2 * err; // error value
                if (e2 > -dy)
                {
                    err -= dy; // adjust error
                    x += sx;
                }
                if (e2 < dx) // adjust error
                {
                    err += dx;
                    y += sy;
                }
            }
        }
        public static void CreateRectangle(Grid grid, int x1, int y1, int x2, int y2) // create rectangle obstacle and it's hard coded
        {
            int minX = Math.Min(x1, x2);
            int maxX = Math.Max(x1, x2);
            int minY = Math.Min(y1, y2);
            int maxY = Math.Max(y1, y2);

            for (int x = minX; x <= maxX; x++)
            {
                for (int y = minY; y <= maxY; y++)
                {
                    grid.SetNodeWalkable(x, y, false);
                }
            }
        }
        public static void ClearObstacles(Grid grid)
        {
            for (int x = 0; x < grid.Width; x++)
            {
                for (int y = 0; y < grid.Height; y++)
                {
                    grid.SetNodeWalkable(x, y, true);
                }
            }
        }
    }
}
