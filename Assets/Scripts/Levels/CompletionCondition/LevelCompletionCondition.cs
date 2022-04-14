using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public abstract class LevelCompletionCondition
{
    [SerializeField]
    private UnityEvent LevelComplete = new UnityEvent();

    protected void Complete()
    {
        LevelComplete?.Invoke();
    }

    public abstract void CheckCondition(int value);
}
