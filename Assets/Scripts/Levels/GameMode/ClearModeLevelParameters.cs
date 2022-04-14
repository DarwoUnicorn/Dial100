using UnityEngine;

public class ClearModeLevelParameters : LevelParameters
{
    [SerializeField]
    ClearCompletionCondition _completionCondition = new ClearCompletionCondition();

    public override LevelCompletionCondition CompletionCondition => _completionCondition;
}
