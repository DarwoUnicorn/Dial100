using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : Ads
{
    [SerializeField]
    private InterstitialTimer _timer;

    public override void ShowAds()
    {
        if(_timer.IsReady)
        {
            Displayer.ShowInterstitial(this);
        }
        else
        {
            AdsOver?.Invoke();
        }
    }
    
    #region "UnityAds"

    public override void OnUnityAdsShowComplete(string adUnit, UnityAdsShowCompletionState showCompletionState)
    {
        base.OnUnityAdsShowComplete(adUnit, showCompletionState);
        _timer.ResetTimer();
        AdsOver?.Invoke();
    }

    #endregion
}
