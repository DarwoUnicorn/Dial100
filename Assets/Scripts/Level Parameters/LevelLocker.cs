using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class LevelLocker
{
    [SerializeField]
    private UnityEvent LevelOpen = new UnityEvent();

    [SerializeField]
    private int RequiredLevel;
    [SerializeField]
    private bool IsRequiredLevelReached;
    [SerializeField]
    private bool IsPreviousLevelCompleted;

    public void OnLevelUp(int newLevel)
    {
        if(newLevel == RequiredLevel)
        {
            IsRequiredLevelReached = true;
            CheckCondition();
        }
    }

    public void OnPreviousLevelComplete()
    {
        IsPreviousLevelCompleted = true;
        CheckCondition();
    }

    private void CheckCondition()
    {
        if(IsPreviousLevelCompleted && IsRequiredLevelReached)
        {
            LevelOpen?.Invoke();
        }
    }
}
