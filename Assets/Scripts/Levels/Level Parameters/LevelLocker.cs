using UnityEngine;
using UnityEngine.Events;

public class LevelLocker : MonoBehaviour
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
