using UnityEngine;

public class ContinueCounter : MonoBehaviour
{
    [SerializeField]
    private int MaxContinueCount;
    
    private int ContinueCount;

    public bool HasContinue { get{ return ContinueCount < MaxContinueCount; } }

    public void ResetContinueCount()
    {
        ContinueCount = 0;
    }

    public void IncreaseCounter()
    {
        ContinueCount++;
    }
}
