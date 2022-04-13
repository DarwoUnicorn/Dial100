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

    public void OnLevelUp(int newLevel)
    {
        if(newLevel >= RequiredLevel)
        {
            IsRequiredLevelReached = true;
            LevelOpen?.Invoke();
        }
    }
}
