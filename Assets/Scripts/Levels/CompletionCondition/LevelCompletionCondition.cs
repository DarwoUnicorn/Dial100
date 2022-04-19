using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public abstract class LevelCompletionCondition
{
    [SerializeField]
    private UnityEvent LevelComplete = new UnityEvent();
    [SerializeField]
    private bool IsCompleted;

    public void Load()
    {
        if(IsCompleted)
        {
            LevelComplete?.Invoke();
        }
    }

    protected void Complete()
    {
        IsCompleted = true;
        LevelComplete?.Invoke();
    }

    public abstract void CheckCondition(int value);
}
