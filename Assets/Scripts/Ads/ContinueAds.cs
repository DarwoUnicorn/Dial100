using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;

public class ContinueAds : Ads
{
    [SerializeField]
    private UnityEvent AdsShowComplete = new UnityEvent();

    [SerializeField]
    private ContinueCounter _continueCounter;

    public override void ShowAds()
    {
        if(_continueCounter.HasContinue == false)
        {
            return;
        }
        Displayer.ShowInterstitial(this);
    }

    #region "UnityAds"

    public override void OnUnityAdsShowComplete(string adUnit, UnityAdsShowCompletionState showCompletionState)
    {
        base.OnUnityAdsShowComplete(adUnit, showCompletionState);
        if(showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            AdsShowComplete?.Invoke();
        }
        AdsOver?.Invoke();
    }

    #endregion
}
