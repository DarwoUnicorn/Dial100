using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private List<List<Cell>> _cells;
    private GameParameters _parameters;

    public IReadOnlyList<IReadOnlyList<Cell>> Cells => _cells;
    public GameParameters Parameters => _parameters;

    public void OnFieldCreated(List<List<Cell>> cells, GameParameters parameters)
    {
        _cells = cells;
        _parameters = parameters;
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
        if(coordinate.x < 0 || coordinate.x >= _parameters.Width ||
           coordinate.y < 0 || coordinate.y >= _parameters.Height)
        {
            return false;
        }
        if(_cells[coordinate.x][coordinate.y] == null)
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
        _cells[coordinate.x][coordinate.y].
            Generate(_parameters.MinStartCellValue, _parameters.MaxStartCellValue);
        MoveCellUp(coordinate);
    }

    public void DeleteCells(bool[,] deleteMap)
    {
        for(int i = deleteMap.GetLength(0) - 1; i >= 0; i--)
        {
            for(int j = deleteMap.GetLength(1) - 1; j >= 0; j--)
            {
                if(deleteMap[i, j] == true)
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
        if(_cells[coordIn.x][coordIn.y].Data.TryIncreaseValue(_cells[coordOut.x][coordOut.y].Data) != true)
        {
            return false;
        }
        return true;
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
            _cells[coordinate.x][i - 1] = _cells[coordinate.x][i];
            _cells[coordinate.x][i] = rising;
        }
    }
}
