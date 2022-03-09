using System.Collections.Generic;
using UnityEngine;

public class FieldColumn
{
    private List<Cell> _cells = new List<Cell>();

    public FieldColumn(int size)
    {
        Size = size;
    }

    public IEnumerable<Cell> Cells => _cells;

    public int Size 
    {
        get
        {
            return _cells.Count;
        }
        set
        {
            if(Size < value)
            {
                for(int i = Size; i < value; i++)
                {
                    _cells.Add(new Cell(Random.Range(1, 21), true));
                }
            }
            else if(Size > value)
            {
                for(int i = Size - 1; i >= value; i--)
                {
                    _cells.RemoveAt(i);
                }
            }
        }
    }

    public Cell this[int index]
    {
        get
        {
            return _cells[index];
        }
    }

    public void DeleteCell(int index)
    {
        _cells.RemoveAt(index);
        _cells.Add(new Cell(Random.Range(1, 21), true));
    }
}
