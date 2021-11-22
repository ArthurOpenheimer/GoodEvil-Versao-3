using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class PathNode
    {
        private Grid<PathNode> grid;
        public int x;
        public int y;

        public int gCost;
        public int hCost;
        public int fCost;

        public bool isWalkable;

        public PathNode cameFrom;

        public PathNode(Grid<PathNode> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
            isWalkable = true;
        }

        public override string ToString()
        {
            return x + "," + y;
        }

        public void CalculateFCost()
        {
            fCost = gCost + hCost;
        }
    }
}
