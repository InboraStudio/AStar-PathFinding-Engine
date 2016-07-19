using System;

namespace AStarPathfindingEngine.Core
{

    public class Grid
    {
        private Node[,] nodes;
        
        public int Width { get; private set; } /// don't Try to change Width and Height from outside 
        public int Height { get; private set; }

        public Grid(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.nodes = new Node[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    nodes[x, y] = new Node(x, y, true);
                }
            }
        }

        public Node GetNode(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
                return null;

            return nodes[x, y];
        }

        public void SetNodeWalkable(int x, int y, bool walkable)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                nodes[x, y].Walkable = walkable;
            }
        }

        public void ResetGrid()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    nodes[x, y].G = 0; // grid reset like we can use it for The node Placement
                    nodes[x, y].H = 0;
                    nodes[x, y].F = 0;
                    nodes[x, y].Parent = null;
                }
            }
        }
    }
}
