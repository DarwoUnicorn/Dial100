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
    private bool IsPreviousLevelComplete;

    public void OnPreviousLevelCompleted()
    {
        IsPreviousLevelComplete = true;
        CheckCondition();
    }

    public void OnLevelUp(int newLevel)
    {
        if(newLevel >= RequiredLevel)
        {
            IsRequiredLevelReached = true;
            CheckCondition();
        }
    }

    private void CheckCondition()
    {
        if(IsRequiredLevelReached && IsPreviousLevelComplete)
        {
            LevelOpen?.Invoke();
        }
    }
}
