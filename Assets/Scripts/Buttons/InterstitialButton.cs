using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterstitialButton : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup _disabledGroup;
    [SerializeField]
    private CanvasGroup _enabledGroup;

    public void ClickOnButton()
    {
        _disabledGroup.alpha = 0;
        _disabledGroup.blocksRaycasts = false;
        _enabledGroup.alpha = 1;
        _enabledGroup.blocksRaycasts = true;
    }
}
