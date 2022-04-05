using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;

public abstract class Ads : MonoBehaviour, IUnityAdsShowListener
{
    [SerializeField]
    protected UnityEvent AdsOver = new UnityEvent();

    [SerializeField]
    protected AdsDisplayer Displayer;

    public abstract void ShowAds();

    public virtual void OnUnityAdsShowFailure(string adUnit, UnityAdsShowError error, string message)
    {
        Debug.Log($"UnityAds. Show failed: { adUnit }, { error.ToString() }, { message }");
    }

    public virtual void OnUnityAdsShowStart(string adUnit)
    {
        Debug.Log($"UnityAds. Show started: { adUnit }");
    }

    public virtual void OnUnityAdsShowClick(string adUnit)
    {
        Debug.Log($"UnityAds. Click: { adUnit }");
    }

    public virtual void OnUnityAdsShowComplete(string adUnit, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log($"UnityAds. Show completed: { adUnit }");
    }
}
