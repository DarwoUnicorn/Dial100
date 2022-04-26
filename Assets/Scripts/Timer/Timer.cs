using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private UnityEvent TimeOver = new UnityEvent();

    public float MaxTime { get; private set; }
    public float RemainingTime { get; private set; }
    public bool IsPaused { get; private set; }

    public void SetParameters(LevelParameters parameters)
    {
        MaxTime = parameters.Timer.MaxTime;
        RemainingTime = MaxTime;
    }

    public void RestoreTime()
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
    }

    #endregion
}
