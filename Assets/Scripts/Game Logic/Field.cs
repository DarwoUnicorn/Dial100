using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private List<List<Cell>> _cells;

    public void SetCells(List<Cell> cells, GameParameters gameParameters)
    {
        _cells = new List<List<Cell>>();
        int k = 0;
        for(int i = 0; i < gameParameters.Width; i++)
        {
            _cells.Add(new List<Cell>());
            for(int j = 0; j < gameParameters.Height; j++)
            {
                if(gameParameters.FieldMap[i, j] == true)
                {
                    _cells[i].Add(cells[k]);
                    k++;
                }
            }
        }
    }
}
