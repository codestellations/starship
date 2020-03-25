﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public bool walkable;
    public Vector2 worldPosition;
    public int gridX;
    public int gridY;

    public float gCost;
    public Node parent;

    public Node(bool _walkable, Vector2 _worldPos, int _gridX, int _gridY){
        walkable = _walkable;
        worldPosition = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
    }

    // public float gCost {
    //     get{
    //         return gCost;
    //     }
    // }
}
