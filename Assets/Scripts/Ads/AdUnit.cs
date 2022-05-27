using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public abstract class AdUnit : MonoBehaviour, IUnityAdsLoadListener
{
    [SerializeField]
    private string _unitId;

    protected bool IsLoading;

    protected string UnitId => _unitId;

    public abstract void Load();

    protected IEnumerator RetryLoad()
    {
        yield return new WaitForSeconds(10);
        Load();
    }

    #region  UnityAdsHandlers

    public virtual void OnUnityAdsAdLoaded(string unitId)
    {
        Debug.Log($"UnityAds. Load complete: { unitId }");
        IsLoading = false;
    }

    public virtual void OnUnityAdsFailedToLoad(string unitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"UnityAds. Load failed: { unitId }, { error }, { message }");
        StartCoroutine(RetryLoad());
    }

    #endregion
}