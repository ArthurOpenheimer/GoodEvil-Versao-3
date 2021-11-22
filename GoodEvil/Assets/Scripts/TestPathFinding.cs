using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPathFinding : MonoBehaviour
{
    public Vector2 start;
    public Vector2 end;
    private PathFinding pathFinding;
    public List<PathNode> unWalkableNodes = new List<PathNode>();
    void Start()
    {
        pathFinding = new PathFinding(10,10);
        Debug.Log("PathFinding: " + pathFinding);
        unWalkableNodes.Add(pathFinding.grid.GetGridObject(1, 1));

        foreach (PathNode node in unWalkableNodes)
        {
            node.isWalkable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            List<PathNode> path = pathFinding.FindPath((int)start.x, (int)start.y, (int)end.x, (int)end.y);
            
            if(path != null)
            {
                foreach(PathNode pathNode in path)
                {
                    Debug.Log("Path: " + pathNode);
                }

                for (int i = 0; i < path.Count -1; i++){
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 1f + Vector3.one * 0.5f, new Vector3(path[i+1].x, path[i+1].y) * 1f + Vector3.one * 0.5f, Color.green, 1000f);
                }
            }
            else
            {
                Debug.Log("No path");
            }
        }
    }
}
