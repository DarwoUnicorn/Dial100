using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private List<List<Cell>> _cells;
    private GameParameters _parameters;

    public IReadOnlyList<IReadOnlyList<Cell>> Cells => _cells;
    public GameParameters Parameters => _parameters;

    public void SetField(List<List<Cell>> cells, GameParameters parameters)
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

    public void OnSwipe(Cell cell, Vector2Int direction)
    {
        Vector2Int element1 = GetCoordinates(cell);
        Vector2Int element2 = element1 + direction;
        if(IsValideCoordinate(element2) == false)
        {
            return;
        }
        TryMove(element1, element2);
    }

    public void DeleteCell(Vector2Int coordinate)
    {
        if(IsValideCoordinate(coordinate) == false)
        {
            throw new System.ArgumentException("Invalid coordinates");
        }
        _cells[coordinate.x][coordinate.y].
            Generate(_parameters.MinStartCellValue, _parameters.MaxStartCellValue);

        if(_parameters.Mode == GameMode.Infinity || _parameters.Mode == GameMode.Level)
        {
            DeleteCells(GetDeleteMap());
        }
    }

    private bool TryMove(Vector2Int coordOut, Vector2Int coordIn)
    {
        if(Mathf.Abs(coordIn.x - coordOut.x) + Mathf.Abs(coordIn.y - coordOut.y) != 1)
        {
            return false;
        }
        if(_cells[coordIn.x][coordIn.y].Data.TryIncreaseValue(_cells[coordOut.x][coordOut.y].Data) != true)
        {
            return false;
        }
        DeleteCell(coordOut);
        if(_parameters.Mode == GameMode.Infinity || _parameters.Mode == GameMode.Level)
        {
            DeleteCells(GetDeleteMap());
        }
        return true;
    }

    private void MoveCellUp(Vector2Int coordinate)
    {
        Cell rising = _cells[coordinate.x][coordinate.y];
        Cell temp;
        for(int i = coordinate.y + 1; i < _cells[coordinate.x].Count; i++)
        {
            if(_cells[coordinate.x][i] == null)
            {
                continue;
            }
            rising.Swap(_cells[coordinate.x][i]);
            temp = rising;
            rising = _cells[coordinate.x][i];
            _cells[coordinate.x][i] = temp;
        }
    }

    private bool[,] GetDeleteMap()
    {
        bool[,] horizontalDeleteMap = new bool[_parameters.Width, _parameters.Height];
        bool[,] verticalDeleteMap = new bool[_parameters.Width, _parameters.Height];
        for(int i = 0; i < _parameters.Height; i++)
        {
            CheckRow(horizontalDeleteMap, i);
        }
        for(int i = 0; i < _parameters.Width; i++)
        {
            CheckColumn(verticalDeleteMap, i);
        }
        return UnionDeleteMap(horizontalDeleteMap, verticalDeleteMap);
    }

    private void CheckRow(bool[,] deleteMap, int rowNumber)
    {
        int counter = 0;
        for(int i = 0; i < _parameters.Width; i++)
        {
            if(_cells[i][rowNumber] != null && _cells[i][rowNumber].Data.IsComplete)
            {
                counter++;
                if(i < _parameters.Width - 1)
                {
                    continue;
                }
            }
            if(counter >= _parameters.FullInRow)
            {
                for(int k = 0; k < counter; k++)
                {
                    deleteMap[i - k, rowNumber] = true;
                }
            }
            counter = 0;
        }
    }

    private void CheckColumn(bool[,] deleteMap, int columnNumber)
    {
        int counter = 0;
        for(int i = 0; i < _parameters.Height; i++)
        {
            if(_cells[columnNumber][i] != null && _cells[columnNumber][i].Data.IsComplete)
            {
                counter++;
                if(i < _parameters.Height - 1)
                {
                    continue;
                }
            }
            if(counter >= _parameters.FullInColumn)
            {
                for(int k = 0; k < counter; k++)
                {
                    deleteMap[columnNumber, i - k] = true;
                }
            }
            counter = 0;
        }
    }

    private bool[,] UnionDeleteMap(bool[,] map1, bool[,] map2)
    {
        for(int i = 0; i < map1.GetLength(0); i++)
        {
            for(int j = 0; j < map1.GetLength(1); j++)
            {
                map1[i, j] = map1[i, j] || map2[i, j];
            }
        }
        return map1;
    }

    private void DeleteCells(bool[,] deleteMap)
    {
        for(int i = deleteMap.GetLength(0) - 1; i >= 0; i--)
        {
            for(int j = deleteMap.GetLength(1); j >= 0; j--)
            {
                if(deleteMap[i, j] == true)
                {
                    DeleteCell(new Vector2Int(i, j));
                }
            }
        }
    }
}
