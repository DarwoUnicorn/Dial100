using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FieldGenerator : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<List<List<Cell>>, GameParameters> FieldCreated = 
        new UnityEvent<List<List<Cell>>, GameParameters>();

    [SerializeField]
    private GameObject _cell;
    [SerializeField]
    private GameObject _emptyCell;

    private List<List<GameObject>> _field = new List<List<GameObject>>();

    public void Generate(GameParameters gameParameters)
    {
        ClearField();
        List<List<Cell>> cells = new List<List<Cell>>();
        for(int i = 0; i < gameParameters.Width; i++)
        {
            cells[i] = new List<Cell>();
            for(int j = 0; j < gameParameters.Height; j++)
            {
                CreateCell(cells[i], gameParameters.FieldMap[i, j]);
                _field[i].Add(cells[i][cells.Count - 1].Parent);
            }
        }
        FieldCreated?.Invoke(cells, gameParameters);
    }

    private void CreateCell(List<Cell> cells, bool IsDataCell)
    {
        if(IsDataCell == true)
        {
            cells.Add(new Cell(Instantiate(_cell)));
        }
        else
        {
            cells.Add(new Cell(Instantiate(_emptyCell)));
        }
    }

    private void ClearField()
    {
        for(int i = 0; i < _field.Count; i++)
        {
            for(int j = 0; j < _field[i].Count; j++)
            {
                Destroy(_field[i][j]);
            }
        }
        _field.Clear();
    }
}
