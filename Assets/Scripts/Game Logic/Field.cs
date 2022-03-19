using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private List<List<Cell>> _cells;
    private GameParameters _parameters;

    public IReadOnlyList<IReadOnlyList<Cell>> CellsData => _cells;
    public GameParameters Parameters => _parameters;

    public void SetField(List<List<Cell>> cellsData, GameParameters parameters)
    {
        _cells = cellsData;
        _parameters = parameters;
    }

    public bool TryMove(Vector2Int coordOut, Vector2Int coordIn)
    {
        if(Mathf.Abs(coordIn.x - coordOut.x) + Mathf.Abs(coordIn.y - coordOut.y) != 1)
        {
            return false;
        }
        if(_cells[coordIn.x][coordIn.y]?.Data.TryIncreaseValue(_cells[coordOut.x][coordOut.y]?.Data) != true)
        {
            return false;
        }
        DeleteCell(coordOut);
        if(_parameters.Mode == GameMode.Infinity || _parameters.Mode == GameMode.Level)
        {
            DeleteCells(CheckFull());
        }
        return true;
    }

    private void DeleteCell(Vector2Int coord)
    {
        _cells[coord.x][coord.y].Data.GenerateValue(_parameters.MinStartCellValue, _parameters.MaxStartCellValue);
        _cells[coord.x][coord.y].State = Cell.ChangeState.Created;
        for(int i = coord.y + 1; i < _cells[coord.x].Count; i++)
        {
            if(_cells[coord.x][i].State != Cell.ChangeState.Created)
            {
                _cells[coord.x][i].State = Cell.ChangeState.Fall;
            }
            Swap(new Vector2Int(coord.x, i), new Vector2Int(coord.x, i - 1));
        }
        
    }

    private void Swap(Vector2Int coord1, Vector2Int coord2)
    {
        GameObject temp = _cells[coord1.x][coord1.y].Parent; 
        _cells[coord1.x][coord1.y].SetParent(_cells[coord2.x][coord2.y].Parent);
        _cells[coord2.x][coord2.y].SetParent(temp);
        Cell tempCell = _cells[coord1.x][coord1.y];
        _cells[coord1.x][coord1.y] = _cells[coord2.x][coord2.y];
        _cells[coord2.x][coord2.y] = tempCell;
    }

    private bool[,] CheckFull()
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

    private void CheckRow(bool[,] deleteMap, int RowNumber)
    {
        int inRow = 0;
        for(int i = 0; i < _parameters.Width; i++)
        {
            if(_cells[i][RowNumber].IsActive && _cells[i][RowNumber].Data.IsComplete)
            {
                inRow++;
                if(i < _parameters.Width - 1)
                {
                    continue;
                }
            }
            if(inRow >= _parameters.FullInRow)
            {
                for(int k = 0; k < inRow; k++)
                {
                    deleteMap[i - k, RowNumber] = true;
                }
            }
        }
    }

    private void CheckColumn(bool[,] deleteMap, int ColumnNumber)
    {
        int inColumn = 0;
        for(int i = 0; i < _parameters.Height; i++)
        {
            if(_cells[ColumnNumber][i].IsActive && _cells[ColumnNumber][i].Data.IsComplete)
            {
                inColumn++;
                if(i < _parameters.Height - 1)
                {
                    continue;
                }
            }
            if(inColumn >= _parameters.FullInRow)
            {
                for(int k = 0; k < inColumn; k++)
                {
                    deleteMap[ColumnNumber, i - k] = true;
                }
            }
        }
    }

    private void DeleteCells(bool[,] deleteMap)
    {
        for(int i = deleteMap.GetLength(0) - 1; i >= 0; i--)
        {
            for(int j = deleteMap.GetLength(1); j >= 0; j--)
            {
                DeleteCell(new Vector2Int(i, j));
            }
        }
    }
}
