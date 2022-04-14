using UnityEngine;

[System.Serializable]
public class ScoreCompletionCondition : LevelCompletionCondition
{
    [SerializeField]
    private int _requiredScore;

    public int RequiredLevel => _requiredScore;

    public override void CheckCondition(int value)
    {
        if(_requiredScore <= value)
        {
            Complete();
        }
    }
}
