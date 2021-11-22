using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class PathFinding
    {
        public Grid<PathNode> grid;
        private List<PathNode> openList;
        private HashSet<PathNode> closeList;
        public int MOVE_STRAIGHT_COST = 10;
        public float MOVE_DIAGONAL_COST = 14;

        public PathFinding(int width, int height)
        {
            grid = new Grid<PathNode>(width, height, 1f, Vector3.zero, 
                (Grid<PathNode> g, int x, int y) => new PathNode(grid, x, y));
        }

        public List<PathNode> FindPath(int startX, int startY, int endX, int endY)
        {
            PathNode startNode = grid.GetGridObject(startX, startY);
            PathNode endNode = grid.GetGridObject(endX, endY);

            openList = new List<PathNode> { startNode };
            closeList = new HashSet<PathNode>();

            for(int x = 0; x < grid.GetWidth(); x++)
            {
                for(int y = 0; y< grid.GetHeight(); y++)
                {
                    PathNode pathNode = grid.GetGridObject(x, y);
                    pathNode.gCost = int.MaxValue;
                    pathNode.CalculateFCost();
                    pathNode.cameFrom = null;
                }
            }

            startNode.gCost = 0;
            startNode.hCost = CalculateDistance(startNode, endNode);
            startNode.CalculateFCost();

            while(openList.Count > 0)
            {
                PathNode currentNode = GetTheLowestFCostNode(openList);

                if(currentNode == endNode)
                {
                    return CalculatePath(endNode);
                }

                openList.Remove(currentNode);
                closeList.Add(currentNode);

                foreach(PathNode neightbourNode in GetNeightbourList(currentNode))
                {
                    if (closeList.Contains(neightbourNode)) continue;
                    if (!neightbourNode.isWalkable)
                    {
                        closeList.Add(neightbourNode);
                        continue;
                    }

                    int tentativeGCost = currentNode.gCost + CalculateDistance(currentNode, neightbourNode);
                    if(tentativeGCost < neightbourNode.gCost)
                    {
                        neightbourNode.cameFrom = currentNode;
                        neightbourNode.gCost = tentativeGCost;
                        neightbourNode.hCost = CalculateDistance(neightbourNode, endNode);
                        neightbourNode.CalculateFCost();

                        if (!openList.Contains(neightbourNode))
                        {
                            openList.Add(neightbourNode);
                        }
                    }
                }
            }

            //out of nodes in the openList
            return null;
        }

        private List<PathNode> GetNeightbourList(PathNode currentNode)
        {
            List<PathNode> neighbourList = new List<PathNode>();

            if(currentNode.x - 1 >= 0)
            {
                //left 
                neighbourList.Add(grid.GetGridObject(currentNode.x - 1, currentNode.y));
                //left down 
                if(currentNode.y - 1 >= 0 ) neighbourList.Add(grid.GetGridObject(currentNode.x - 1, currentNode.y -1));
                //left up 
                if (currentNode.y + 1 < grid.GetWidth()) neighbourList.Add(grid.GetGridObject(currentNode.x - 1, currentNode.y + 1));
            }
            if (currentNode.x + 1 < grid.GetWidth())
            {
                //left 
                neighbourList.Add(grid.GetGridObject(currentNode.x + 1, currentNode.y));
                //left down 
                if (currentNode.y - 1 >= 0) neighbourList.Add(grid.GetGridObject(currentNode.x + 1, currentNode.y - 1));
                //left up 
                if (currentNode.y - 1 < grid.GetHeight()) neighbourList.Add(grid.GetGridObject(currentNode.x + 1, currentNode.y + 1));
            }

            if (currentNode.y - 1 >= 0)
            {
                //down
                neighbourList.Add(grid.GetGridObject(currentNode.x, currentNode.y - 1));
            }
            if (currentNode.y + 1 < grid.GetHeight())
            {
                //down
                neighbourList.Add(grid.GetGridObject(currentNode.x, currentNode.y + 1));
            }

            return neighbourList;
        }

        private List<PathNode> CalculatePath(PathNode endNode)
        {
            List<PathNode> path = new List<PathNode>();

            path.Add(endNode);
            PathNode currentNode = endNode;
            while (currentNode.cameFrom != null)
            {
                path.Add(currentNode.cameFrom);

                currentNode = currentNode.cameFrom;
            }

            path.Reverse();
            return path;
        }


        private int CalculateDistance(PathNode a, PathNode b)
        {
            float xDistance = MathF.Abs(a.x - b.x);
            float yDistance = MathF.Abs(a.y - b.y);
            float remaining = MathF.Abs(xDistance - yDistance);

            return (int)(MOVE_DIAGONAL_COST * MathF.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining);
        }

        private PathNode GetTheLowestFCostNode(List<PathNode> pathNodeList)
        {
            PathNode lowestFCostNode = pathNodeList[0];
            for (int i = 1; i < pathNodeList.Count; i++)
            {
                if(pathNodeList[i].fCost < lowestFCostNode.fCost)
                {
                    lowestFCostNode = pathNodeList[i];
                }
            }

            return lowestFCostNode;
        }
    }
}
