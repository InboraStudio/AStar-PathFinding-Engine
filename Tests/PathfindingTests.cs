using System;
using System.Collections.Generic;
using AStarPathfindingEngine.Core;
using AStarPathfindingEngine.Utils;

namespace AStarPathfindingEngine.Tests
{
   
    public class PathfindingTests
    {
        // Test basic pathfinding
public static bool TestSimplePath()
        {
            Console.WriteLine("Running: TestSimplePath"); /// Nice console output 
            Grid grid = new Grid(10, 10);
            AStar pathfinder = new AStar(grid);

            Node start = grid.GetNode(0, 0);
            Node end = grid.GetNode(9, 9);

            List<Node> path = pathfinder.FindPath(start, end);

            bool result = path.Count > 0 && path[0] == start && path[path.Count - 1] == end;
            Console.WriteLine($"  Result: {(result ? "PASS" : "FAIL")} (Path length: {path.Count})"); // Nice console output Line
            return result;
        }

        // Test navigation around barriers
public static bool TestPathWithObstacles()
        {
            Console.WriteLine("Running: TestPathWithObstacles");
            Grid grid = new Grid(10, 10);

            for (int i = 2; i < 8; i++)
            {
                grid.SetNodeWalkable(5, i, false);
            }

            AStar pathfinder = new AStar(grid);
            Node start = grid.GetNode(2, 5);
            Node end = grid.GetNode(8, 5);

            List<Node> path = pathfinder.FindPath(start, end);

            bool result = path.Count > 0;
            Console.WriteLine($"  Result: {(result ? "PASS" : "FAIL")} (Path length: {path.Count})"); // same
            return result;
        }

        // Test unreachable destination
public static bool TestNoPathAvailable()
        {
            Console.WriteLine("Running: TestNoPathAvailable"); // same
            Grid grid = new Grid(10, 10);

            for (int i = 0; i < 10; i++)
            {
                grid.SetNodeWalkable(5, i, false);
            }

            AStar pathfinder = new AStar(grid);
            Node start = grid.GetNode(2, 5);
            Node end = grid.GetNode(8, 5);

            List<Node> path = pathfinder.FindPath(start, end);

            bool result = path.Count == 0;
            Console.WriteLine($"  Result: {(result ? "PASS" : "FAIL")} (Path length: {path.Count})"); // same
            return result;
        }

        public static void RunAllTests()
        {
            Console.WriteLine("=== Running All Tests ===\n"); // nice console output

            int passed = 0;
            int total = 0;

            total++;
            if (TestSimplePath()) passed++;

            total++;
            if (TestPathWithObstacles()) passed++; /// am not sure about this line

            total++;
            if (TestNoPathAvailable()) passed++;

            Console.WriteLine($"\n=== Results: {passed}/{total} tests passed ===");
        }
    }
}
