using UnityEngine;
using UnityEngine.Advertisements;

public class AdsDisplayer : MonoBehaviour
{
    [SerializeField]
    private AdsLoader _adsLoader;

    public void ShowInterstitial(IUnityAdsShowListener listener)
    {
        Advertisement.Show(AdUnit._interstitial, listener);
        _adsLoader.LoadUnit(AdUnit._interstitial);
    }

    public void ShowRewarded(IUnityAdsShowListener listener)
    {
        Advertisement.Show(AdUnit._rewarded, listener);
        _adsLoader.LoadUnit(AdUnit._rewarded);
    
    }

    public void ShowBanner(IUnityAdsShowListener listener)
    {
        Advertisement.Show(AdUnit._banner, listener);
        _adsLoader.LoadUnit(AdUnit._banner);
    }
}
