using UnityEngine;
using UnityEngine.Events;

public class GameLogic : MonoBehaviour
{
    [SerializeField]
    private UnityEvent FieldChange = new UnityEvent();
    [SerializeField]
    private UnityEvent MovesOver = new UnityEvent();
    [SerializeField]
    private UnityEvent<int> IncreasePoints = new UnityEvent<int>();
    [SerializeField]
    private UnityEvent Dial100 = new UnityEvent();

    [SerializeField]
    private Field _field;

    public GameParameters Parameters => _field.Parameters;

    public void Restart()
    {
        foreach(var column in _field.Cells)
        {
            foreach(var cell in column)
            {
                cell?.Generate(Parameters.MinStartCellValue, Parameters.MaxStartCellValue);
            }
        }
        FieldChange?.Invoke();
    }

    public void OnSwipe(Cell cell, Vector2Int direction)
    {
        Vector2Int elementOut = _field.GetCoordinates(cell);
        Vector2Int elementIn = elementOut + direction;
        if(_field.IsValideCoordinate(elementIn) == false)
        {
            return;
        }
        if(_field.TryMove(elementOut, elementIn) == false)
        {
            return;
        }
        if(_field.Cells[elementIn.x][elementIn.y].Data.Value == 100)
        {
            Dial100?.Invoke();
        }
        IncreasePoints?.Invoke(_field.Cells[elementIn.x][elementIn.y].Data.Value);
        DeleteCell(elementOut);
    }

    public void DeleteCell(Vector2Int coordinate)
    {
        _field.DeleteCell(coordinate);
        if(Parameters.Mode == GameMode.Infinity || Parameters.Mode == GameMode.Level)
        {
            _field.DeleteCells(GetDeleteMap());
        }
        FieldChange?.Invoke();
        if(_field.HasMove() == false)
        {
            MovesOver?.Invoke();
        }
    }

    private bool[,] GetDeleteMap()
    {
        bool[,] horizontalDeleteMap = new bool[Parameters.Width, Parameters.Height];
        bool[,] verticalDeleteMap = new bool[Parameters.Width, Parameters.Height];
        for(int i = 0; i < Parameters.Height; i++)
        {
            CheckRow(horizontalDeleteMap, i);
        }
        for(int i = 0; i < Parameters.Width; i++)
        {
            CheckColumn(verticalDeleteMap, i);
        }
        return UnionDeleteMap(horizontalDeleteMap, verticalDeleteMap);
    }

    private void CheckRow(bool[,] deleteMap, int rowNumber)
    {
        int counter = 0;
        for(int i = 0; i < Parameters.Width; i++)
        {
            if(_field.Cells[i][rowNumber] != null && _field.Cells[i][rowNumber].Data.IsComplete)
            {
                counter++;
                if(i < Parameters.Width - 1)
                {
                    continue;
                }
            }
            if(counter >= Parameters.FullInRow)
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
        for(int i = 0; i < Parameters.Height; i++)
        {
            if(_field.Cells[columnNumber][i] != null && _field.Cells[columnNumber][i].Data.IsComplete)
            {
                counter++;
                if(i < Parameters.Height - 1)
                {
                    continue;
                }
            }
            if(counter >= Parameters.FullInColumn)
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
}
