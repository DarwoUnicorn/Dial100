using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FieldGenerator : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<List<List<Cell>>, GameParameters> FieldCreated = 
        new UnityEvent<List<List<Cell>>, GameParameters>();

    [SerializeField]
    private Transform _fieldParent;
    [SerializeField]
    private GameObject _cell;
    [SerializeField]
    private GameObject _emptyCell;

    private List<List<GameObject>> _field = new List<List<GameObject>>();

    public void Generate(GameParameters gameParameters)
    {
        if(gameParameters == null)
        {
            throw new System.ArgumentNullException(gameParameters.ToString());
        }
        ClearField();
        List<List<Cell>> cells = new List<List<Cell>>();
        for(int i = 0; i < gameParameters.Width; i++)
        {
            cells.Add(new List<Cell>());
            _field.Add(new List<GameObject>());
            for(int j = 0; j < gameParameters.Height; j++)
            {
                CreateCell(cells[i], _field[i], gameParameters.FieldMap[i, j]);
            }
        }
        FieldCreated?.Invoke(cells, gameParameters);
    }

    private void CreateCell(List<Cell> cells, List<GameObject> field, bool IsActive)
    {
        if(IsActive)
        {
            field.Add(Instantiate(_cell, _fieldParent));
            cells.Add(field[field.Count - 1].GetComponent<Cell>());
        }
        else
        {
            field.Add(Instantiate(_emptyCell, _fieldParent));
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
