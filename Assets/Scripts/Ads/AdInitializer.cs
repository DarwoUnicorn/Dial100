using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Advertisements;

public class AdInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField]
    private UnityEvent UnityAdInitialized = new UnityEvent();

    [SerializeField]
    private bool _testMode;

    private string _gameId = "4570003";

    private IEnumerator RetryInitialization()
    {
        yield return new WaitForSeconds(30);
        Initialize();
    } 

    #region UnityAdsHandlers

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
        Debug.Log($"UnityAds. Initialization failed - { error.ToString() }: { message }");
        StartCoroutine(RetryInitialization());
    }

    #endregion

    #region MonoBehaviour
    
    private void Start()
    {
        Initialize();
    }

    #endregion
}
