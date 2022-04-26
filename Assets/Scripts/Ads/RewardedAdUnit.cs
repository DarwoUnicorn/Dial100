using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAdUnit : AdUnit
{
    [SerializeField]
    private ContinueCounter _continueCounter;

    public override void Load()
    {
        Advertisement.Load(UnitId, this);
    }

    public void Show(IUnityAdsShowListener listener)
    {
        Advertisement.Show(UnitId, listener);
        Load();
    }
}
