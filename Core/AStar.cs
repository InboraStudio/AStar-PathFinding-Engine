using System;
using System.Collections.Generic;
using System.Linq;

namespace AStarPathfindingEngine.Core
{
    /// its the main funcation
    // Version 1.0
public class AStar
    {
        private List<Node> openSet;
        private List<Node> closedSet;
        private Grid grid;

        public AStar(Grid grid)
        {
            this.grid = grid;
            this.openSet = new List<Node>();
            this.closedSet = new List<Node>();
        }
        public List<Node> FindPath(Node startNode, Node endNode) // this is long funcation
        {
            openSet.Clear();
            closedSet.Clear();

            openSet.Add(startNode);
            startNode.G = 0;
            startNode.H = CalculateHeuristic(startNode, endNode);
            startNode.F = startNode.H;

            // Main A* loop
while (openSet.Count > 0)
            {
                int current = 0;
                for (int i = 1; i < openSet.Count; i++)
                {
                    if (openSet[i].F < openSet[current].F)
                    {
                        current = i;
                    }
                }

                Node currentNode = openSet[current];

                if (currentNode == endNode)
                {
                    return RetracePath(startNode, endNode);
                }

                openSet.RemoveAt(current);
                closedSet.Add(currentNode);

                foreach (Node neighbor in GetNeighbors(currentNode)) // foreach loop
                {
                    if (closedSet.Contains(neighbor) || !neighbor.Walkable)
                        continue;

                    float newG = currentNode.G + GetDistance(currentNode, neighbor);

                    if (openSet.Contains(neighbor))
                    {
                        if (newG < neighbor.G)
                        {
                            neighbor.G = newG;
                            neighbor.Parent = currentNode;
                            neighbor.F = neighbor.G + neighbor.H; // added this line to update F cost so we can find the optimal path 
                        }
                    }
                    else
                    {
                        neighbor.G = newG;
                        neighbor.H = CalculateHeuristic(neighbor, endNode);
                        neighbor.F = neighbor.G + neighbor.H;
                        neighbor.Parent = currentNode;
                        openSet.Add(neighbor);
                    }
                }
            }

            return new List<Node>();
        }

        // Find all neighboring nodes
private List<Node> GetNeighbors(Node node)
        {
            List<Node> neighbors = new List<Node>();

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    int checkX = node.X + x;
                    int checkY = node.Y + y;

                    if (checkX >= 0 && checkX < grid.Width && checkY >= 0 && checkY < grid.Height)
                    {
                        neighbors.Add(grid.GetNode(checkX, checkY));
                    }
                }
            }

            return neighbors;
        }

        // Manhattan distance heuristic
private float CalculateHeuristic(Node a, Node b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }

        // Calculate movement cost
private float GetDistance(Node a, Node b)
        {
            float dx = Math.Abs(a.X - b.X);
            float dy = Math.Abs(a.Y - b.Y);

            if (dx + dy == 1)
                return 1;
            else
                return 1.4f;
        }

        private List<Node> RetracePath(Node startNode, Node endNode)
        {
            List<Node> path = new List<Node>();
            Node current = endNode;

            while (current != startNode)
            {
                path.Add(current);
                current = current.Parent;
            }

            path.Add(startNode);
            path.Reverse();

            return path;
        }
    }
}
