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

    public bool OnLevelUp(int newLevel)
    {
        if(newLevel >= RequiredLevel)
        {
            IsRequiredLevelReached = true;
            CheckCondition();
            return true;
        }
        return false;
    }

    public void CheckCondition()
    {
        if(IsRequiredLevelReached)
        {
            LevelOpen?.Invoke();
        }
    }
}
