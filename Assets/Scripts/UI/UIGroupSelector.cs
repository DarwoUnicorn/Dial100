using System.Collections.Generic;
using UnityEngine;

public class UIGroupSelector : MonoBehaviour
{
    [SerializeField]
    private UIPage _startedPage;
    
    private UIPage _activePage;
    private UIWindow _activeWindow;

    public void SetActivePage(UIPage page)
    {
        if(page == null)
        {
            throw new System.ArgumentNullException(page.ToString());
        }
        DisableGroup(_activePage.Group);
        _activePage = page;
        EnableGroup(_activePage.Group);
    }

    public void SetActiveWindow(UIWindow window)
    {
        if(window == null)
        {
            throw new System.ArgumentNullException(window.ToString());
        }
        if(_activeWindow != null)
        {
            DisableGroup(_activeWindow.Group);
        }
        _activeWindow = window;
        EnableGroup(_activeWindow.Group);
        _activePage.Group.blocksRaycasts = false;
    }

    public void DisableActiveWindow()
    {
        if(_activeWindow != null)
        {
            DisableGroup(_activeWindow.Group);
            _activeWindow = null;
            _activePage.Group.blocksRaycasts = true;
        }
    }

    private void Start()
    {
        if(_startedPage == null)
        {
            throw new System.NullReferenceException(_startedPage.ToString());
        }
        DisableAllGroup();
        _activePage = _startedPage;
        EnableGroup(_activePage.Group);
    }

    private void DisableAllGroup()
    {
        List<CanvasGroup> disabledGroup = new List<CanvasGroup>();
        gameObject.GetComponentsInChildren<CanvasGroup>(disabledGroup);
        foreach(CanvasGroup item in disabledGroup)
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