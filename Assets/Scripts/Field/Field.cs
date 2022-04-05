using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Field : MonoBehaviour
{
    [SerializeField]
    private UnityEvent ResetMaxStartCellValue = new UnityEvent();

    private List<List<Cell>> _cells;
    private GameParameters _parameters;
    private int _maxStartValue;
    private int _movesBeforeResetMaxStartValue = -1;

    public IReadOnlyList<IReadOnlyList<Cell>> Cells => _cells;
    public GameParameters Parameters => _parameters;

    public void OnCellsGenerated(List<List<Cell>> cells, GameParameters parameters)
    {
        _cells = cells;
        _parameters = parameters;
        _maxStartValue = parameters.MaxStartCellValue;

    }

    public void ResetMaxStartValue()
    {
        if(_movesBeforeResetMaxStartValue != 0)
        {
            _maxStartValue = _parameters.MaxStartCellValue;
            _movesBeforeResetMaxStartValue = 0;
            ResetMaxStartCellValue?.Invoke();
        }
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
        if(x < 0 || x >= _parameters.Width ||
           y < 0 || y >= _parameters.Height)
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
        _cells[coordinate.x][coordinate.y].
            Generate(_parameters.MinStartCellValue, _maxStartValue);
        MoveCellUp(coordinate);
        if(_movesBeforeResetMaxStartValue == 0)
        {
            return;
        }
        _movesBeforeResetMaxStartValue--;
        if(_movesBeforeResetMaxStartValue == 0)
        {
            _maxStartValue = _parameters.MaxStartCellValue;
            ResetMaxStartCellValue?.Invoke();
        }
    }

    public void DeleteCells(bool[,] deleteMap)
    {
        bool HasDeleted = false;
        for(int i = deleteMap.GetLength(0) - 1; i >= 0; i--)
        {
            for(int j = deleteMap.GetLength(1) - 1; j >= 0; j--)
            {
                if(deleteMap[i, j] == true)
                {
                    HasDeleted = true;
                    DeleteCell(new Vector2Int(i, j));
                }
            }
        }
        if(HasDeleted)
        {
            DeleteCells(GetDeleteMap());
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

    public void DescreaseMaxStartValue()
    {
        _maxStartValue = _parameters.MaxStartCellValue - 10;
        _movesBeforeResetMaxStartValue = 10;
    }

    public bool[,] GetDeleteMap()
    {
        bool[,] deleteMap = new bool[_parameters.Width, _parameters.Height];
        for(int i = 0; i < _parameters.Height; i++)
        {
            CheckRow(deleteMap, i);
        }
        for(int i = 0; i < _parameters.Width; i++)
        {
            CheckColumn(deleteMap, i);
        }
        return deleteMap;
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

    private bool CheckAround(int x, int y)
    {
        if(IsValideCoordinate(x - 1, y) && _cells[x][y].Data.Value + _cells[x - 1][y].Data.Value <= 100)
        {
            return true;
        }
        if(IsValideCoordinate(x + 1, y) && _cells[x][y].Data.Value + _cells[x + 1][y].Data.Value <= 100)
        {
            return true;
        }
        if(IsValideCoordinate(x, y - 1) && _cells[x][y].Data.Value + _cells[x][y - 1].Data.Value <= 100)
        {
            return true;
        }
        if(IsValideCoordinate(x, y + 1) && _cells[x][y].Data.Value + _cells[x][y + 1].Data.Value <= 100)
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
