using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Field : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<int> DeleteRows = new UnityEvent<int>();
    [SerializeField]
    private UnityEvent<int> DeleteColumns = new UnityEvent<int>();
    [SerializeField]
    private UnityEvent<Cell, Cell> Move = new UnityEvent<Cell, Cell>();

    private List<List<Cell>> _cells;
    private LevelParameters _parameters;

    public IReadOnlyList<IReadOnlyList<Cell>> Cells => _cells;
    public LevelParameters Parameters => _parameters;

    public void OnCellsGenerated(List<List<Cell>> cells, LevelParameters parameters)
    {
        _cells = cells;
        _parameters = parameters;
    }

    public bool HasMove()
    {
        for(int i = 0; i < _cells.Count; i++)
        {
            for(int j = 0; j < _cells[i].Count; j++)
            {
                if(IsValideCoordinate(i, j) && CheckAround(i, j))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public int CountOfFullCell()
    {
        int fullCellCount = 0;
        foreach(var column in _cells)
        {
            foreach(var cell in column)
            {
                if(cell?.IsComplete == true)
                {
                    fullCellCount++;
                }
            }
        }
        return fullCellCount;
    }

    public Vector2Int GetCoordinates(Cell cell)
    {
        if(cell == null)
        {
            throw new System.ArgumentNullException(cell.ToString());
        }
        for(int i = 0; i < _cells.Count; i++)
        {
            int index = _cells[i].FindIndex(item => item == cell);
            if(index != -1)
            {
                return new Vector2Int(i, index);
            }
        }
        throw new System.ArgumentException("The cell is not contained in the field");
    }

    public bool IsValideCoordinate(Vector2Int coordinate)
    {
        return IsValideCoordinate(coordinate.x, coordinate.y);
    }

    public bool IsValideCoordinate(int x, int y)
    {
        if(x < 0 || x >= _parameters.Field.Width ||
           y < 0 || y >= _parameters.Field.Height)
        {
            return false;
        }
        if(_cells[x][y] == null)
        {
            return false;
        }
        return true;
    }

    public void DeleteCell(Vector2Int coordinate)
    {
        if(IsValideCoordinate(coordinate) == false)
        {
            throw new System.ArgumentException("Invalid coordinates");
        }
        _cells[coordinate.x][coordinate.y].Generate();
        MoveCellUp(coordinate);
    }

    public void DeleteCells(bool[,] deleteMap)
    {
        for(int i = deleteMap.GetLength(0) - 1; i >= 0; i--)
        {
            for(int j = deleteMap.GetLength(1) - 1; j >= 0; j--)
            {
                if(deleteMap[i, j] && _cells[i][j] != null)
                {
                    DeleteCell(new Vector2Int(i, j));
                }
            }
        }
    }

    public bool TryMove(Vector2Int coordOut, Vector2Int coordIn)
    {
        if(Mathf.Abs(coordIn.x - coordOut.x) + Mathf.Abs(coordIn.y - coordOut.y) != 1)
        {
            return false;
        }
        if(_cells[coordIn.x][coordIn.y].Value + _cells[coordOut.x][coordOut.y].Value <= 100)
        {
            Move?.Invoke(_cells[coordOut.x][coordOut.y], _cells[coordIn.x][coordIn.y]);
            _cells[coordIn.x][coordIn.y].TryIncreaseValue(_cells[coordOut.x][coordOut.y]);
            return true;
        }
        return false;
    }

    public bool[,] GetDeleteMap()
    {
        bool[,] deleteMap = new bool[_parameters.Field.Width, _parameters.Field.Height];
        int rowCount = 0;
        int columnCount = 0;
        for(int i = 0; i < _parameters.Field.Height; i++)
        {
            if(CheckRow(deleteMap, i))
            {
                rowCount++;
            }
        }
        for(int i = 0; i < _parameters.Field.Width; i++)
        {
            if(CheckColumn(deleteMap, i))
            {
                columnCount++;
            }
        }
        DeleteColumns?.Invoke(columnCount);
        DeleteRows?.Invoke(rowCount);
        return deleteMap;
    }

    private bool CheckRow(bool[,] deleteMap, int rowNumber)
    {
        for(int i = 0; i < _parameters.Field.Width; i++)
        {
            if(_cells[i][rowNumber]?.IsComplete == false)
            {
                return false;
            }
        }
        for(int i = 0; i < _parameters.Field.Width; i++)
        {
            deleteMap[i, rowNumber] = true;
        }
        return true;
    }

    private bool CheckColumn(bool[,] deleteMap, int columnNumber)
    {
        for(int i = 0; i < _parameters.Field.Height; i++)
        {
            if(_cells[columnNumber][i]?.IsComplete == false)
            {
                return false;
            }
        }
        for(int i = 0; i < _parameters.Field.Height; i++)
        {
            deleteMap[columnNumber, i] = true;
        }
        return true;
    }

    private bool CheckAround(int x, int y)
    {
        if(IsValideCoordinate(x - 1, y) && _cells[x][y].Value + _cells[x - 1][y].Value <= 100)
        {
            return true;
        }
        if(IsValideCoordinate(x + 1, y) && _cells[x][y].Value + _cells[x + 1][y].Value <= 100)
        {
            return true;
        }
        if(IsValideCoordinate(x, y - 1) && _cells[x][y].Value + _cells[x][y - 1].Value <= 100)
        {
            return true;
        }
        if(IsValideCoordinate(x, y + 1) && _cells[x][y].Value + _cells[x][y + 1].Value <= 100)
        {
            return true;
        }
        return false;
    }

    private void MoveCellUp(Vector2Int coordinate)
    {
        Cell rising = _cells[coordinate.x][coordinate.y];
        for(int i = coordinate.y + 1; i < _cells[coordinate.x].Count; i++)
        {
            if(_cells[coordinate.x][i] == null)
            {
                continue;
            }
            rising.Swap(_cells[coordinate.x][i]);
            _cells[coordinate.x][coordinate.y] = _cells[coordinate.x][i];
            _cells[coordinate.x][i] = rising;
            coordinate.Set(coordinate.x, i);
        }
    }
}
