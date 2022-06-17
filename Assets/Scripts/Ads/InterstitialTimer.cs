using UnityEngine;

public class InterstitialTimer : MonoBehaviour
{
    [SerializeField]
    private float _timeBetweenAd;
    
    private float _remainingTime; 

    public bool IsReady { get { return _remainingTime <= 0; } }

    public void ResetTimer()
    {
        _remainingTime = _timeBetweenAd;
    }

    #region MonoBehaviour

    private void Start()
    {
        _remainingTime = _timeBetweenAd * 1.5f;
    }

    private void Update()
    {
        if(_remainingTime > 0)
        {
            _remainingTime -= Time.deltaTime;
        }
    }

    #endregion
}
