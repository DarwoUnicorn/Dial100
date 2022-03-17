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
}
