using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public abstract class AdUnit : MonoBehaviour, IUnityAdsLoadListener
{
    [SerializeField]
    private string _unitId;

    protected string UnitId { get; }

    public abstract void Load();

    protected IEnumerator RetryLoad()
    {
        yield return new WaitForSeconds(30);
        Load();
    }

    #region  UnityAdsHandlers

    public void OnUnityAdsAdLoaded(string unitId)
    {
        Debug.Log($"UnityAds. Load complete: { unitId }");
    }

    public void OnUnityAdsFailedToLoad(string unitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"UnityAds. Load failed: { unitId }, { error }, { message }");
        StartCoroutine(RetryLoad());
    }

    #endregion
}