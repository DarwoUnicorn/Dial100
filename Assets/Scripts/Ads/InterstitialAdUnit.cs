using UnityEngine.Advertisements;

public class InterstitialAdUnit : AdUnit
{
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
        Load();
    }
}
