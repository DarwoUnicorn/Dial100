using UnityEngine;

public class LevelParameters : MonoBehaviour
{
    [SerializeField]
    private TimerParameters _timer;
    [SerializeField]
    private FieldParameters _field;
    [SerializeField]
    private LevelLocker _levelLocker;
    [SerializeField]
    private LevelHighScore _highScore;
    [SerializeField]
    private LevelCompletionCondition _completionCondition;
    [SerializeField]
    private bool _allowBonuses;

    public TimerParameters Timer => _timer;
    public FieldParameters Field => _field;
    public LevelLocker Locker => _levelLocker;
    public LevelHighScore HighScore => _highScore;
    public LevelCompletionCondition CompletionCondition => _completionCondition;
    public bool AllowBonuses => _allowBonuses;

    public void CheckCondition(int value)
    {
        CompletionCondition.CheckCondition(value);
    }

    public void SetHighScore(int score)
    {
        _highScore.SetHighScore(score);
    }

    public void OnLevelUp(int newLevel)
    {
        _levelLocker.OnLevelUp(newLevel);
    }
}
