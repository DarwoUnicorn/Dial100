using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldColumn
{
    public FieldColumn(int size)
    {
        Size = size;
    }

    private List<Cell> _cells = new List<Cell>();

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
                    _cells.Add(new Cell(Random.Range(1, 21)));
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
        private set
        {
            _cells[index] = value;
        }
    }

    public void SetCell(Cell newCell, int index)
    {
        _cells[index] = newCell;
    }

    public void DeleteCell(int index)
    {
        _cells.RemoveAt(index);
        _cells.Add(new Cell(Random.Range(1, 21)));
    }
}
