using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerator : MonoBehaviour
{
    [SerializeField]
    private GameParameters _gameParameters;
    [SerializeField]
    private GameObject _cell;

    private List<GameObject> _fieldCells = new List<GameObject>();

    public void Generate()
    {
        if(_fieldCells.Count > _gameParameters.Width * _gameParameters.Height)
        {
            ClearField();
        }
        
    }

    private void ClearField()
    {
        foreach(var item in _fieldCells)
        {
            Destroy(item);
        }
        _fieldCells.Clear();
    }
}
