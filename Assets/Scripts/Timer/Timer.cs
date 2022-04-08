using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private UnityEvent TimeOver = new UnityEvent();

    private TimerParameters _parameters;
    private float _timeBeforeDecrease;
    private float _minTime;
    private float _decreaseTime = 40;
    private bool _readyForDecrease { get { return _timeBeforeDecrease == 0; } }

    public float MaxTime { get; private set; }
    public float RemainingTime { get; private set; }
    public bool IsPaused { get; private set; }

    public void SetParameters(LevelParameters parameters)
    {
        _parameters = parameters.Timer;
        _minTime = _parameters.MinTime;
        Reset();
    }

    public void Reset()
    {
        MaxTime = _parameters.MaxTime;
        RemainingTime = MaxTime;
        _timeBeforeDecrease = _decreaseTime;
        Pause();
    }

    public void RestoreTime()
    {
        if(_readyForDecrease)
        {
            MaxTime -= 1;
            _timeBeforeDecrease = _decreaseTime;
            if(MaxTime < _minTime)
            {
                MaxTime = _minTime;
            }
        }
        RemainingTime = MaxTime;
    }

    public void Pause()
    {
        IsPaused = true;
    }

    public void Continue()
    {
        IsPaused = false;
    }

    #region "MonoBehaviour"

    private void Start()
    {
        IsPaused = true;
        MaxTime = 1;
    }

    private void Update()
    {
        if(IsPaused)
        {
            return;
        }
        RemainingTime -= Time.deltaTime;
        if(RemainingTime <= 0)
        {
            Pause();
            TimeOver?.Invoke();
        }
        if(MaxTime > _minTime || _readyForDecrease)
        {
            return;
        }
        _timeBeforeDecrease -= Time.deltaTime;
    }

    #endregion
}
