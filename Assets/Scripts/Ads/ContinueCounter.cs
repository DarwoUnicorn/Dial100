using System;
using UnityEngine;

public class ContinueCounter : MonoBehaviour
{
    public event Action Reset;

    [SerializeField]
    private int _maxContinueCount;
    
    private int _continueCount;

    public bool HasContinue { get { return _continueCount < _maxContinueCount; } }

    public void ResetContinueCount()
    {
        _continueCount = 0;
        Reset?.Invoke();
    }

    public void IncreaseCounter()
    {
        _continueCount++;
    }
}
