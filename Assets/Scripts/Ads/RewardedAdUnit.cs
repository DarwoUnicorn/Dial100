using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Advertisements;

public class RewardedAdUnit : AdUnit
{
    [SerializeField]
    private UnityEvent AdNotLoaded = new UnityEvent();
    [SerializeField]
    private UnityEvent AdLoaded = new UnityEvent();

    [SerializeField]
    private ContinueCounter _continueCounter;

    public override void Load()
    {
        if(IsLoading)
        {
            return;
        }
        IsLoading = true;
        Advertisement.Load(UnitId, this);
    }

    public void Show(IUnityAdsShowListener listener)
    {
        Advertisement.Show(UnitId, listener);
        AdNotLoaded?.Invoke();
        Load();
    }

    public override void OnUnityAdsAdLoaded(string unitId)
    {
        base.OnUnityAdsAdLoaded(unitId);
        AdLoaded?.Invoke();
    }

    public override void OnUnityAdsFailedToLoad(string unitId, UnityAdsLoadError error, string message)
    {
        base.OnUnityAdsFailedToLoad(unitId, error, message);
        AdNotLoaded?.Invoke();
    }
}
