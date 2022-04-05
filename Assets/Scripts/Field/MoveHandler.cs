using UnityEngine;
using UnityEngine.Events;

public class MoveHandler : MonoBehaviour
{
    [SerializeField]
    private UnityEvent FieldChanged = new UnityEvent();
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
        _field.ResetMaxStartValue();
        FieldChanged?.Invoke();
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

    public void ClearBottom()
    {
        bool[,] deleteMap = new bool[Parameters.Width, Parameters.Height];
        int rowCount = Parameters.Height < 4 ? 1 : 2;
        for(int i = 0; i < Parameters.Width; i++)
        {
            for(int j = 0; j < rowCount; j++)
            {
                deleteMap[i, j] = true;
            }
        }
        _field.DeleteCells(deleteMap);
        FieldChanged?.Invoke();
    }

    public void DeleteCell(Cell cell)
    {
        DeleteCell(_field.GetCoordinates(cell));
    }

    public void DeleteCell(Vector2Int coordinate)
    {
        _field.DeleteCell(coordinate);
        if(Parameters.Mode == GameMode.Infinity || Parameters.Mode == GameMode.Clear)
        {
            _field.DeleteCells(_field.GetDeleteMap());
        }
        FieldChanged?.Invoke();
        if(_field.HasMove() == false)
        {
            MovesOver?.Invoke();
        }
    }
}
