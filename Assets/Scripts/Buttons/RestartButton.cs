using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Advertisements;

public class RestartButton : IButton, IUnityAdsShowListener
{
    [SerializeField]
    private UnityEvent Restart = new UnityEvent();

    [SerializeField]
    private InterstitialTimer _timer;
    [SerializeField]
    private InterstitialAdUnit _adUnit;
    
    public override void Action()
    {
        if(_timer.IsReady)
        {
            _adUnit.Show(this);
            return;
        }
        Restart?.Invoke();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"UnityAds. { placementId }, { error }, { message }");
        Restart?.Invoke();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log($"UnityAds. { placementId } show start");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log($"UnityAds. { placementId } click");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log($"UnityAds. { placementId }, show complete");
        _timer.ResetTimer();
        Restart?.Invoke();
    }
}

