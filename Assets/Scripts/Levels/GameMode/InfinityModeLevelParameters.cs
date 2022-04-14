using UnityEngine;

public class InfinityModeLevelParameters : LevelParameters
{
    [SerializeField]
    ScoreCompletionCondition _completionCondition = new ScoreCompletionCondition();

    public override LevelCompletionCondition CompletionCondition => _completionCondition;
}
