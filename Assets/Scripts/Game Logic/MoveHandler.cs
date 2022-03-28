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
