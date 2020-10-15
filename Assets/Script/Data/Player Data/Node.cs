using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    // Start is called before the first frame update
    public int gridX;
    public int gridY;

    public bool isWall;
    public Vector3 Position;

    public Node Parent;

    public int gCost;
    public int hCost;

    public int FCost { get { return gCost + hCost; } }

    public Node(bool a_isWall, Vector3 a_pos, int a_gridX, int b_gridY)
    {
        isWall = a_isWall;
        Position = a_pos;
        gridX = a_gridX;
        gridY = b_gridY;
    }   
}
