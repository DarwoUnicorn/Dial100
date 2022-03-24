using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private UnityEvent TimeOver = new UnityEvent();

    private float _timeBeforeDecrease;
    private float _minTime;
    private float _decreaseTime = 40;

    public float MaxTime { get; private set; }
    public float RemainingTime { get; private set; }
    public bool IsPaused { get; private set; }

    public void SetGameParameters(GameParameters parameters)
    {
        MaxTime = parameters.MaxTime;
        _minTime = parameters.MinTime;
        RemainingTime = MaxTime;
        _timeBeforeDecrease = _decreaseTime;
    }

    public void Reset()
    {
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

    private void Start()
    {
        IsPaused = true;
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
        if(MaxTime > _minTime)
        {
            return;
        }
        _timeBeforeDecrease -= Time.deltaTime;
        if(_timeBeforeDecrease <= 0)
        {
            MaxTime -= 1;    
        }
        if(MaxTime < _minTime)
        {
            MaxTime = _minTime;
        }
    }
}
