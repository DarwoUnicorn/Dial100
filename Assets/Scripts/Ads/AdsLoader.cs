using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsLoader : MonoBehaviour, IUnityAdsLoadListener
{
    public void OnUnityAdsInitialized()
    {
        LoadUnit(AdUnit._interstitial);
        LoadUnit(AdUnit._rewarded);
        LoadUnit(AdUnit._banner);
    }

    public void LoadUnit(string adUnit)
    {
        Advertisement.Load(adUnit);
    }

    private IEnumerator RetryInitialization(string adUnit)
    {
        yield return new WaitForSeconds(30);
        LoadUnit(adUnit);
    }

    #region "UnityAds"

    public void OnUnityAdsAdLoaded(string adUnit)
    {
        Debug.Log($"UnityAds. Load complete: { adUnit }");
    }

    public void OnUnityAdsFailedToLoad(string adUnit, UnityAdsLoadError error, string message)
    {
        Debug.Log($"UnityAds. Load failed: { adUnit }, { error.ToString() }, { message }");
        RetryInitialization(adUnit);
    }

    #endregion
}
