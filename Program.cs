using System;
using System.Collections.Generic;
using AStarPathfindingEngine.Core;
using AStarPathfindingEngine.Utils;
using AStarPathfindingEngine.Visualization;
using AStarPathfindingEngine.Tests;
using AStarPathfindingEngine.Examples;

namespace AStarPathfindingEngine
{
    class Program
    {
        static void Main(string[] args) // entry point
        {
            Console.WriteLine("=== A* Pathfinding Algorithm Engine ===\n");

            DisplayMenu();
        }

        static void DisplayMenu() // a small gui it for my console app
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n-- in Menu --");
                Console.WriteLine("1. Run Basic Example");
                Console.WriteLine("2. Run Maze Example");
                Console.WriteLine("3. Run Performance Test");
                Console.WriteLine("4. Run Unit Tests");
                Console.WriteLine("5. Exit");
                Console.Write("\nSelect option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ExampleScenarios.BasicExample();
                        break;
                    case "2":
                        ExampleScenarios.MazeExample();
                        break;
                    case "3":
                        ExampleScenarios.PerformanceExample();
                        break;
                    case "4":
                        PathfindingTests.RunAllTests();
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                if (running && (input == "1" || input == "2" || input == "3" || input == "4"))
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}
