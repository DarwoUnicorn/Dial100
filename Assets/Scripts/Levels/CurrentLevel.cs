using UnityEngine;
using UnityEngine.Events;

public class CurrentLevel : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<LevelParameters> LevelChanged = new UnityEvent<LevelParameters>();

    private LevelParameters _level;

    public void SetLevel(LevelParameters level)
    {
        _level = level;
        LevelChanged?.Invoke(level);
    }
}
