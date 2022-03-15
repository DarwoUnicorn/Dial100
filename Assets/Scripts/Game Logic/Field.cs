using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private List<List<CellData>> _cellsData;
    private List<List<GameObject>> _cells;
    private GameParameters _parameters;

    public IReadOnlyList<IReadOnlyList<CellData>> CellsData => _cellsData;
    public IReadOnlyList<IReadOnlyList<GameObject>> Cells => _cells;
    public GameParameters Parameters => _parameters;

    public void SetField(List<List<CellData>> cellsData, List<List<GameObject>> cells, GameParameters parameters)
    {
        _cells = cells;
        _cellsData = cellsData;
        _parameters = parameters;
    }
}
