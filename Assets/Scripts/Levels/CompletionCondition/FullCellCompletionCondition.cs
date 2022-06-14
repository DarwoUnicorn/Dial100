using System.Collections.Generic;
using UnityEngine;

public class FullCellCompletionCondition : LevelCompletionCondition
{
    [SerializeField]
    private List<int> _requiredFullCells;

    public List<int> RequiredFullCells => _requiredFullCells;

    public override void CheckCondition(int value)
    {
        int stars = 0;
        for(int i = 0; i < _requiredFullCells.Count; i++)
        {
            if(_requiredFullCells[i] > value)
            {
                break;
            }
            stars++;
        }
        Complete(stars);
    }
}
