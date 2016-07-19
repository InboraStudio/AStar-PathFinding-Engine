namespace AStarPathfindingEngine
{
    public class Node
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool Walkable { get; set; }
        
        public float G { get; set; }
        public float H { get; set; }
        public float F { get; set; }
        
        public Node Parent { get; set; }

        public Node(int x, int y, bool walkable = true) // constructor
        {
            this.X = x;
            this.Y = y;
            this.Walkable = walkable;
            this.G = 0;
            this.H = 0;
            this.F = 0;
            this.Parent = null;
        }
    }
}
