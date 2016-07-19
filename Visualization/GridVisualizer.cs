using System;
using System.Collections.Generic;
using AStarPathfindingEngine.Core;

namespace AStarPathfindingEngine.Visualization
{
    public class GridVisualizer
    {
        private Grid grid;

        public GridVisualizer(Grid grid)
        {
            this.grid = grid;
        }
        public void DisplayGrid(List<Node> path = null, Node start = null, Node end = null) // thanks for Cs Xenon Book for this idea
        {
            Console.Clear();

            for (int y = 0; y < grid.Height; y++)
            {
                for (int x = 0; x < grid.Width; x++)
                {
                    Node node = grid.GetNode(x, y);

                    if (start != null && node.X == start.X && node.Y == start.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("S ");
                    }
                    else if (end != null && node.X == end.X && node.Y == end.Y)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("E ");
                    }
                    else if (path != null && path.Contains(node))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("* ");
                    }
                    else if (!node.Walkable)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("# ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(". ");
                    }
                }
                Console.WriteLine();
            }

            Console.ResetColor();
        }
        public void DisplayGridWithStats(List<Node> path, Node start, Node end) // new method to show stats
        {
            DisplayGrid(path, start, end);

            Console.WriteLine("\n--- Path Statistics ---");
            Console.WriteLine($"Start: ({start.X}, {start.Y})");
            Console.WriteLine($"End: ({end.X}, {end.Y})");
            Console.WriteLine($"Path Length: {path.Count}");
            Console.WriteLine($"Grid Size: {grid.Width}x{grid.Height}");
        }
    }
}
