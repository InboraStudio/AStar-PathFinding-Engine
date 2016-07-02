using System;
using System.Collections.Generic;
using AStarPathfindingEngine.Core;
using AStarPathfindingEngine.Utils;
using AStarPathfindingEngine.Visualization;

namespace AStarPathfindingEngine.Examples
{
    public class ExampleScenarios
    {
        // Simple grid with random obstacles
public static void BasicExample()
        {
            Console.WriteLine("--- Basic Pathfinding Example ---\n");

            Grid grid = new Grid(15, 15);
            GridUtilities.CreateRandomObstacles(grid, 20);

            Node start = grid.GetNode(1, 1);
            Node end = grid.GetNode(13, 13);

            AStar pathfinder = new AStar(grid);
            List<Node> path = pathfinder.FindPath(start, end);

            GridVisualizer visualizer = new GridVisualizer(grid);
            visualizer.DisplayGridWithStats(path, start, end);
        }

        public static void MazeExample()
        {
            Console.WriteLine("\n--- Maze Pathfinding Example ---\n");

            Grid grid = new Grid(20, 20);

            GridUtilities.CreateWall(grid, 5, 0, 5, 15);
            GridUtilities.CreateWall(grid, 10, 5, 10, 20);
            GridUtilities.CreateWall(grid, 15, 0, 15, 15);

            Node start = grid.GetNode(1, 1);
            Node end = grid.GetNode(19, 19);

            AStar pathfinder = new AStar(grid);
            List<Node> path = pathfinder.FindPath(start, end);

            GridVisualizer visualizer = new GridVisualizer(grid);
            visualizer.DisplayGridWithStats(path, start, end);
        }

        public static void PerformanceExample()
        {
            Console.WriteLine("\n--- Performance Testing Example ---\n");

            Grid grid = new Grid(50, 50);
            GridUtilities.CreateRandomObstacles(grid, 300);

            Node start = grid.GetNode(1, 1);
            Node end = grid.GetNode(48, 48);

            PerformanceMonitor monitor = new PerformanceMonitor();
            AStar pathfinder = new AStar(grid);

            monitor.Start();
            List<Node> path = pathfinder.FindPath(start, end);
            monitor.Stop();

            monitor.PrintResults("Pathfinding");
            Console.WriteLine($"Path found: {(path.Count > 0 ? "Yes" : "No")}");
            Console.WriteLine($"Path length: {path.Count} nodes");
        }
    }
}
