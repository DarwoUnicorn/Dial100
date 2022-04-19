using UnityEngine;

public abstract class LevelParameters : MonoBehaviour, IPersistent
{
    [SerializeField]
    private TimerParameters _timer = new TimerParameters();
    [SerializeField]
    private FieldParameters _field = new FieldParameters();
    [SerializeField]
    private LevelLocker _levelLocker = new LevelLocker();
    [SerializeField]
    private LevelHighScore _highScore = new LevelHighScore();
    [SerializeField]
    private bool _allowBonuses;
    [SerializeField]
    private string _id;

    public TimerParameters Timer => _timer;
    public FieldParameters Field => _field;
    public LevelLocker Locker => _levelLocker;
    public LevelHighScore HighScore => _highScore;
    public bool AllowBonuses => _allowBonuses;
    public string Id => _id;
    public abstract LevelCompletionCondition CompletionCondition { get; }

    public void CheckCondition(int value)
    {
        CompletionCondition.CheckCondition(value);
        Save();
    }

    public void SetHighScore(int score)
    {
        _highScore.SetHighScore(score);
        Save();
    }

    public void OnLevelUp(int newLevel)
    {
        if(_levelLocker.OnLevelUp(newLevel))
        {
            Save();
        }
    }

    public void Save()
    {
        Saver.Save(this);
    }

    public void Load()
    {
        Saver.Load(this);
    }

    #region "MonoBehaviour"

    private void Awake()
    {
        Load();
        CompletionCondition.Load();
        _levelLocker.CheckCondition();
        _highScore.UpdateScore();
        OnValidate();
    }

    private void OnValidate()
    {
        _timer.OnValidate();
        _field.OnValidate();
    }

    #endregion
}
