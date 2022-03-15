using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FieldGenerator : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<List<List<CellData>>, List<List<GameObject>>, GameParameters> FieldCreated = 
        new UnityEvent<List<List<CellData>>, List<List<GameObject>>, GameParameters>();

    [SerializeField]
    private GameObject _cell;
    [SerializeField]
    private GameObject _emptyCell;

    private List<List<GameObject>> _field = new List<List<GameObject>>();

    public void Generate(GameParameters gameParameters)
    {
        ClearField();
        List<List<CellData>> cellsData = new List<List<CellData>>();
        for(int i = 0; i < gameParameters.Width; i++)
        {
            cellsData[i] = new List<CellData>();
            for(int j = 0; j < gameParameters.Height; j++)
            {
                CreateCell(cellsData[i], gameParameters, i, j);
            }
        }
        FieldCreated?.Invoke(cellsData, _field, gameParameters);
    }

    private void CreateCell(List<CellData> cellsData, GameParameters gameParameters, int xCoord, int yCoord)
    {
        if(gameParameters.FieldMap[xCoord, yCoord] == true)
        {
            _field[xCoord].Add(Instantiate(_cell, gameObject.transform));
            cellsData.Add(_field[xCoord][_field.Count - 1].GetComponentInChildren<CellData>());
            cellsData[cellsData.Count - 1].GenerateValue(gameParameters.MinStartCellValue, gameParameters.MaxStartCellValue);
            cellsData[cellsData.Count - 1].SetCoordinates(xCoord, yCoord);
        }
        else
        {
            _field[xCoord].Add(Instantiate(_emptyCell, gameObject.transform));
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
