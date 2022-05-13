using UnityEngine;
using UnityEngine.Events;

public class LevelLocker : MonoBehaviour
{
    [SerializeField]
    private UnityEvent LevelOpen = new UnityEvent();

    [SerializeField]
    private int RequiredLevel;

    public void OnLevelUp(int newLevel)
    {
        if(newLevel >= RequiredLevel)
        {
            LevelOpen?.Invoke();
        }
    }
}
