using System.Collections.Generic;
using UnityEngine;

public class UIPageManager : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup _startedGroup;
    
    private CanvasGroup _currentGroup;

    public void SetCurrentGroup(CanvasGroup newCanvasGroup)
    {
        if(newCanvasGroup == null)
        {
            throw new System.ArgumentNullException(newCanvasGroup.ToString());
        }
        DisableGroup(_currentGroup);
        _currentGroup = newCanvasGroup;
        EnableGroup(_currentGroup);
    }

    private void Start()
    {
        DisableAllGroup();
        if(_startedGroup == null)
        {
            throw new System.NullReferenceException(_startedGroup.ToString());
        }
        else
        {
            _currentGroup = _startedGroup;
            EnableGroup(_currentGroup);
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
        group.alpha = 0;
        group.blocksRaycasts = false;
    }

    private void EnableGroup(CanvasGroup group)
    {
        group.alpha = 1;
        group.blocksRaycasts = true;
    }
}
