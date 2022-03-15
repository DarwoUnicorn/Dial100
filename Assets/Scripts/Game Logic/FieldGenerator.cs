using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FieldGenerator : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<List<Cell>, GameParameters> FieldCreated = new UnityEvent<List<Cell>, GameParameters>();
    
    [SerializeField]
    private GameObject _cell;
    [SerializeField]
    private GameObject _emptyCell;

    private List<GameObject> _field = new List<GameObject>();

    public void Generate(GameParameters gameParameters)
    {
        ClearField();
        List<Cell> cells = new List<Cell>();
        for(int i = 0; i < gameParameters.Width; i++)
        {
            for(int j = 0; j < gameParameters.Height; j++)
            {
                CreateCell(cells, gameParameters, i, j);
            }
        }
        FieldCreated?.Invoke(cells, gameParameters);
    }

    private void CreateCell(List<Cell> cells, GameParameters gameParameters, int xCoord, int yCoord)
    {
        if(gameParameters.FieldMap[xCoord, yCoord] == true)
        {
            _field.Add(Instantiate(_cell, gameObject.transform));
            cells.Add(_field[_field.Count - 1].GetComponentInChildren<Cell>());
            if(cells == null)
            {
                Debug.Log("Object don't has cell component");
            }
            cells[cells.Count - 1].GenerateValue(gameParameters.MinStartCellValue, gameParameters.MaxStartCellValue);
            cells[cells.Count - 1].TryChangeCoordinates(xCoord, yCoord);
        }
        else
        {
            _field.Add(Instantiate(_emptyCell, gameObject.transform));
        }
    }

    private void ClearField()
    {
        for(int i = 0; i < _field.Count; i++)
        {
            Destroy(_field[i]);
        }
        _field.Clear();
    }
}
