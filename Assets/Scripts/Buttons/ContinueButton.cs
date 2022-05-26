using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class ContinueButton : IButton, IUnityAdsShowListener
{
    [SerializeField]
    private UnityEvent ShowComplete = new UnityEvent();
    [SerializeField]
    private UnityEvent ShowFailure = new UnityEvent();

    [SerializeField]
    private ContinueCounter _counter;
    [SerializeField]
    private RewardedAdUnit _adUnit;
    [SerializeField]
    private Button _button;
    
    private bool IsLoaded = false;

    public void Start()
    {
        _counter.Reset += CheckCondition;
    }

    public void OnDestroy()
    {
        if(_counter != null)
        {
            _counter.Reset -= CheckCondition;
        }
    }

    public override void Action()
    {
        if(_counter.HasContinue)
        {
            _counter.IncreaseCounter();
            _adUnit.Show(this);
            CheckCondition();
            return;
        }
        ShowFailure?.Invoke();
    }

    public void OnAdLoaded()
    {
        IsLoaded = true;
        CheckCondition();
    }

    public void OnAdNotLoaded()
    {
        IsLoaded = false;
        CheckCondition();
    }

    private void CheckCondition()
    {
        if(IsLoaded && _counter.HasContinue)
        {
            _button.interactable = true;
            return;
        }
        _button.interactable = false;
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"UnityAds. { placementId }, { error }, { message }");
        ShowFailure?.Invoke();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log($"UnityAds. { placementId } show start");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log($"UnityAds. { placementId } click");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log($"UnityAds. { placementId }, show complete");
        if(showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            ShowComplete?.Invoke();
            return;
        }
        ShowFailure?.Invoke();
    }
}
