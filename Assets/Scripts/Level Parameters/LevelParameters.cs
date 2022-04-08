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
    private bool _allowBonuses;

    public GameMode Mode => _mode;
    public TimerParameters Timer => _timer;
    public FieldParameters Field => _field;
    public bool AllowBonuses => _allowBonuses;

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
