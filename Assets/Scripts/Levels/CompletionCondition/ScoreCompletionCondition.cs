using System.Collections.Generic;
using UnityEngine;

public class ScoreCompletionCondition : LevelCompletionCondition
{
    [SerializeField]
    private List<int> _requiredScore;

    public List<int> RequiredScore => _requiredScore;

    public override void CheckCondition(int value)
    {
        int stars = 0;
        for(int i = 0; i < _requiredScore.Count; i++)
        {
            if(_requiredScore[i] > value)
            {
                break;
            }
            stars++;
        }
        Complete(stars);
    }
}
