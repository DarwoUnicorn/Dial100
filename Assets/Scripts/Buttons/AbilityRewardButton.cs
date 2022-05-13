using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Advertisements;

public class AbilityRewardButton : IButton, IUnityAdsShowListener
{
    [SerializeField]
    private UnityEvent ShowComplete = new UnityEvent();
    [SerializeField]
    private UnityEvent ShowFailure = new UnityEvent();

    [SerializeField]
    private RewardedAdUnit _adUnit;

    public override void Action()
    {
        _adUnit.Show(this);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"UnityAds. { placementId }, { error }, { message }");
        ShowFailure?.Invoke();
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
        if(showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            ShowComplete?.Invoke();
            return;
        }
        ShowFailure?.Invoke();
    }
}
