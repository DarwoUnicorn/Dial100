using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FieldGenerator : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<List<List<Cell>>, GameParameters> CellsGenerated = 
        new UnityEvent<List<List<Cell>>, GameParameters>();
    [SerializeField]
    private UnityEvent<List<List<GameObject>>> FieldCreated =
        new UnityEvent<List<List<GameObject>>>();

    [SerializeField]
    private Transform _cellsParent;
    [SerializeField]
    private GameObject _cell;
    [SerializeField]
    private GameObject _emptyCell;

    private List<List<GameObject>> _field = new List<List<GameObject>>();

    public void Generate(GameParameters parameters)
    {
        if(parameters == null)
        {
            throw new System.ArgumentNullException(parameters.ToString());
        }
        ClearField();
        List<List<Cell>> cells = GenerateField(parameters);
        CellsGenerated?.Invoke(cells, parameters);
        FieldCreated?.Invoke(_field);
    }

    private List<List<Cell>> GenerateField(GameParameters parameters)
    {
        List<List<Cell>> cells = new List<List<Cell>>();
        for(int i = 0; i < parameters.Width; i++)
        {
            cells.Add(new List<Cell>());
            _field.Add(new List<GameObject>());
            for(int j = parameters.Height - 1; j >= 0; j--)
            {
                CreateCell(cells[i], _field[i], parameters.FieldMap[i][j]);
                cells[i][cells[i].Count - 1]?.Generate(parameters.MinStartCellValue,
                                                       parameters.MaxStartCellValue);
            }
            cells[i].Reverse();
            _field[i].Reverse();
        }
        return cells;
    }

    private void CreateCell(List<Cell> cells, List<GameObject> field, bool IsActive)
    {
        if(IsActive)
        {
            field.Add(Instantiate(_cell, _cellsParent));
            cells.Add(field[field.Count - 1].GetComponentInChildren<Cell>());
        }
        else
        {
            field.Add(Instantiate(_emptyCell, _cellsParent));
            cells.Add(null);
        }
    }

    private void ClearField()
    {
        foreach(var column in _field)
        {
            foreach(var item in column)
            {
                if(item != null)
                {
                    Destroy(item);
                }
            }
        }
        _field.Clear();
    }
}
