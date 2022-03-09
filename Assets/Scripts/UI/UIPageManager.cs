using System.Collections.Generic;
using UnityEngine;

public class UIPageManager : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup _startedGroup;
    
    private CanvasGroup _currentGroup;

    public void SetCurrentGroup(CanvasGroup newCanvasGroup)
    {
        DisableGroup(_currentGroup);
        _currentGroup = newCanvasGroup;
        EnableGroup(_currentGroup);
    }

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
        List<CanvasGroup> disabledGroups = new List<CanvasGroup>();
        gameObject.GetComponentsInChildren<CanvasGroup>(disabledGroups);
        foreach(CanvasGroup item in disabledGroups)
        {
            DisableGroup(item);
        }
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
