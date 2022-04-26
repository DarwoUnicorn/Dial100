using UnityEngine;

public class ContinueCounter : MonoBehaviour
{
    [SerializeField]
    private int _maxContinueCount;
    
    private int _continueCount;

    public bool HasContinue { get { return _continueCount < _maxContinueCount; } }

    public void ResetContinueCount()
    {
        _continueCount = 0;
    }

    public void IncreaseCounter()
    {
        _continueCount++;
    }
}
