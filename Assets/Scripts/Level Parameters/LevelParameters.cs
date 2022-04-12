using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "New Level", order = 51)]
public class LevelParameters : ScriptableObject
{
    [SerializeField]
    private GameMode _mode;
    [SerializeField]
    private TimerParameters _timer = new TimerParameters();
    [SerializeField]
    private FieldParameters _field = new FieldParameters();
    [SerializeField]
    private LevelLocker _levelLocker = new LevelLocker();
    [SerializeField]
    private bool _allowBonuses;
    [SerializeField] [HideInInspector]
    private LevelHighScore _highScore = new LevelHighScore();

    public GameMode Mode => _mode;
    public TimerParameters Timer => _timer;
    public FieldParameters Field => _field;
    public bool AllowBonuses => _allowBonuses;
    public LevelHighScore HighScore => _highScore;

    public void SetHighScore(int score)
    {
        _highScore.SetHighScore(score);
    }

    public void OnLevelUp(int newLevel)
    {
        _levelLocker.OnLevelUp(newLevel);
    }

    public void OnPreviousLevelComplete()
    {
        _levelLocker.OnPreviousLevelComplete();
    }

    #region "MonoBehaviour"

    private void Awake()
    {
        OnValidate();
    }

    private void OnValidate()
    {
        _timer.OnValidate();
        _field.OnValidate();
    }

    #endregion
}
