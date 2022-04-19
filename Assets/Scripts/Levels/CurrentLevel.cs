using UnityEngine;
using UnityEngine.Events;

public class CurrentLevel : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<LevelParameters> LevelChanged = new UnityEvent<LevelParameters>();
    [SerializeField]
    private Score _score;

    private LevelParameters _level;

    public LevelParameters Level => _level;

    public void SetLevel(LevelParameters level)
    {
        _level = level;
        LevelChanged?.Invoke(level);
    }

    public void SetHighScore()
    {
        _level.SetHighScore(_score.Points);
    }
}
