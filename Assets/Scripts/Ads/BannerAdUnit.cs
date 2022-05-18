using UnityEngine;
using UnityEngine.Advertisements;

public  class BannerAdUnit : AdUnit
{
    [SerializeField]
    private BannerPosition _bannerPosition;

    private BannerLoadOptions _loadOptions;
    private BannerOptions _bannerOptions;

    public override void Load()
    {
        Advertisement.Banner.Load(UnitId, _loadOptions);
    }

    public  void Show()
    {
        Advertisement.Banner.Show(UnitId, _bannerOptions);
        StartCoroutine(RetryLoad());
    }

    public void Hide()
    {
        Advertisement.Banner.Hide();
    }

    private void CreateLoadOptions()
    {
        _loadOptions = new BannerLoadOptions();
        _loadOptions.loadCallback = OnBannerLoadCompleted;
        _loadOptions.errorCallback = OnBannerLoadFailed;
    }

    private void CreateBannerOptions()
    {
        _bannerOptions = new BannerOptions();
        _bannerOptions.clickCallback = OnBannerClicked;
        _bannerOptions.hideCallback = OnBannerHiden;
        _bannerOptions.showCallback = OnBannerShown;
    }

    #region UnityAdsHandlers

    private void OnBannerLoadCompleted()
    {
        Debug.Log($"UnityAds. { UnitId } - load complete");
        Show();
    }

    private void OnBannerLoadFailed(string message)
    {
        Debug.Log($"UnityAds. { UnitId } - load failed: { message }");
        StartCoroutine(RetryLoad());
    }

    private void OnBannerClicked()
    {
        Debug.Log($"UnityAds. { UnitId } - clicked");
    }

    private void OnBannerShown()
    {
        Debug.Log($"UnityAds. { UnitId } - shown");
        StartCoroutine(RetryLoad());
    }

    private void OnBannerHiden()
    {
        Debug.Log($"UnityAds. { UnitId } - hiden");
    }

    #endregion

    #region MonoBehaviour

    private void Awake()
    {
        CreateLoadOptions();
        CreateBannerOptions();
    }

    private void Start()
    {
        Advertisement.Banner.SetPosition(_bannerPosition);
    }

    #endregion
}
