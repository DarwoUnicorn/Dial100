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
        if(_fieldCells.Count < _gameParameters.Width * _gameParameters.Height)
        {
            for(int i = _fieldCells.Count; i < _gameParameters.Width * _gameParameters.Height; i++)
            {
                _fieldCells.Add(Instantiate(_cell, gameObject.transform));
            }
        }
        else if(_fieldCells.Count > _gameParameters.Width * _gameParameters.Height)
        {
            for(int i = _fieldCells.Count - 1; i >= _gameParameters.Width * _gameParameters.Height; i--)
            {
                Destroy(_fieldCells[i]);
                _fieldCells.RemoveAt(i);
            }
        }
    }
}
