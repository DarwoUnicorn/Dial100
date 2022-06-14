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
    private UnityEvent<int> Dial100s = new UnityEvent<int>();

    [SerializeField]
    private Field _field;
    [SerializeField]
    private int Count100s;

    public LevelParameters Parameters => _field.Parameters;

    public void Restart()
    {
        foreach(var column in _field.Cells)
        {
            foreach(var cell in column)
            {
                cell?.Generate();
            }
        }
        Reset100s();
        FieldChanged?.Invoke();
    }
    
    public void Reset100s()
    {
        Count100s = 0;
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
        if(_field.Cells[elementIn.x][elementIn.y].Value == 100)
        {
            Count100s++;
            Dial100s?.Invoke(Count100s);
            Dial100?.Invoke();
        }
        IncreasePoints?.Invoke(_field.Cells[elementIn.x][elementIn.y].Value);
        DeleteCell(elementOut);
    }

    public void ClearBottom()
    {
        bool[,] deleteMap = new bool[Parameters.Field.Width, Parameters.Field.Height];
        for(int i = 0; i < Parameters.Field.Width; i++)
        {
            deleteMap[i, 0] = true;
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
        if(Parameters.CompletionCondition is ClearCompletionCondition || Parameters.CompletionCondition is ScoreCompletionCondition)
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
