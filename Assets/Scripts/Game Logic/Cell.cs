using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public Cell(int data)
    {
        Data = data;
    }

    public int Data { get; private set; }
    public Vector2Int Coordinates { get; private set; }
    public Vector2Int PreviousCoordinates { get; private set; }
    public bool IsComplete { get { return Data == 100; } }

    public bool TrySum(Cell other)
    {
        if(Data + other.Data <= 100)
        {
            Data += other.Data;
            return true;
        }
        return false;
    }
}
