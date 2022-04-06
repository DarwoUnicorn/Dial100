using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputHammerInterpreter : InputInterpreter
{
    [SerializeField]
    private UnityEvent<Cell> UsingHammer = new UnityEvent<Cell>();
    
    [SerializeField]
    private EventSystem _eventSystem;

    private void CheckTouch(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(_eventSystem);
        eventData.position = touch.position;
        List<RaycastResult> result = new List<RaycastResult>();
        Raycaster.Raycast(eventData, result);
        Cell cell;
        foreach(var item in result)
        {
            cell = item.gameObject.GetComponentInChildren<Cell>();
            if(cell != null)
            {
                UsingHammer?.Invoke(cell);
            }
        }
    }

    #region "MonoBehaviour"

    private void Update()
    {
        if(IsActive == false || Input.touchCount == 0)
        {
            return;
        }
        Touch touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began)
        {
            CheckTouch(touch);
        }
    }

    private void OnDisable()
    {
        IsActive = false;
    }

    private void OnEnable()
    {
        IsActive = true;
    }

    #endregion
}
