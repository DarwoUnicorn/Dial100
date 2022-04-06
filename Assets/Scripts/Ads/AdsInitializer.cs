using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField]
    private UnityEvent UnityAdsInitialized = new UnityEvent();

    [SerializeField]
    private bool _testMode;

    private string _gameId = "4570003";
    private bool _isInitialized;

    private IEnumerator RetryInitialization()
    {
        yield return new WaitForSeconds(30);
        Initialize();
    } 

    #region "UnityAds" 

    public void Initialize()
    {
        Advertisement.Initialize(_gameId, _testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("UnityAds. Initialization complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"UnityAds. Initialization failed: { error.ToString() }");
        StartCoroutine(RetryInitialization());
    }

    #endregion

    #region "MonoBehaviour"
    
    private void Start()
    {
        Initialize();
    }

    #endregion
}
