using UnityEngine;

public class FinalModeLevelParameters : LevelParameters
{
    [SerializeField]
    FullCellCompletionCondition _completionCondition = new FullCellCompletionCondition();

    public override LevelCompletionCondition CompletionCondition => _completionCondition;
}
