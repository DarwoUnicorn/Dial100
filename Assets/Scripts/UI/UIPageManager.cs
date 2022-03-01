using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPageManager : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup _startedGroup;
    
    private CanvasGroup _currentGroup;

    private void Start()
    {
        DisableAllGroup();
        if(_startedGroup == null)
        {
            Debug.LogWarning("UIPageManager: StartedGroup not set.");
        }
        else
        {
            _currentGroup = _startedGroup;
            _currentGroup.alpha = 1;
            _currentGroup.blocksRaycasts = true;
        }
    }

    private void DisableAllGroup()
    {
        List<CanvasGroup> _disabledGroup = new List<CanvasGroup>();
        gameObject.GetComponentsInChildren<CanvasGroup>(_disabledGroup);
        foreach(CanvasGroup item in _disabledGroup)
        {
            DisableGroup(item);
        }
    }

    public void SetCurrentGroup(CanvasGroup newCanvasGroup)
    {
        DisableGroup(_currentGroup);
        _currentGroup = newCanvasGroup;
        EnableGroup(_currentGroup);
    }

    private void DisableGroup(CanvasGroup group)
    {
        if(group != null)
        {
            group.alpha = 0;
            group.blocksRaycasts = false;
        }
    }

    private void EnableGroup(CanvasGroup group)
    {
        if(group != null)
        {
            group.alpha = 1;
            group.blocksRaycasts = true;
        }
    }
}
