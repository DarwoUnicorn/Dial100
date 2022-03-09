using System.Collections.Generic;
using UnityEngine;

public class CellsGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject _cell;

    private List<GameObject> _fieldCells = new List<GameObject>();

    public void Generate(GameParameters gameParameters)
    {
        if(_fieldCells.Count < gameParameters.Width * gameParameters.Height)
        {
            for(int i = _fieldCells.Count; i < gameParameters.Width * gameParameters.Height; i++)
            {
                _fieldCells.Add(Instantiate(_cell, gameObject.transform));
            }
        }
        else if(_fieldCells.Count > gameParameters.Width * gameParameters.Height)
        {
            for(int i = _fieldCells.Count - 1; i >= gameParameters.Width * gameParameters.Height; i--)
            {
                Destroy(_fieldCells[i]);
                _fieldCells.RemoveAt(i);
            }
        }
    }
}
