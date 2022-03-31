using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputHammerInterpreter : InputInterpreter
{
    [SerializeField]
    private UnityEvent<Cell> UsingHammer = new UnityEvent<Cell>();

    private void Update()
    {
        if(Input.touchCount == 0)
        {
            return;
        }
        Touch touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began)
        {
            CheckTouch(touch);
        }
    }

    private void CheckTouch(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(_eventSystem);
        eventData.position = Camera.current.WorldToScreenPoint(touch.position);
        List<RaycastResult> result = new List<RaycastResult>();
        _graphicRaycaster.Raycast(eventData, result);
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
}
