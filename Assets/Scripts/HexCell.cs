﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HexCell : MonoBehaviour
{
    public HexCoordinates coordinates;
    public int Elevation {
        get { return elevation; }
        set
        {
            elevation = value;
            Vector3 position = transform.localPosition;
            position.y = value * HexMetrics.elevationStep;
            transform.localPosition = position;
        }
    }
    int elevation;
    public Color color;
    [SerializeField]
    HexCell[] neighbors;
    public HexCell GetNeighbor (HexDirection direction)
    {
        return neighbors[(int)direction];
    }
    public void SetNeighbor (HexDirection direction, HexCell cell)
    {
        neighbors[(int)direction] = cell;
        cell.neighbors[(int)direction.Opposite()] = this;
    }
}
