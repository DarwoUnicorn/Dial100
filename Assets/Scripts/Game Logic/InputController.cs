using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<Cell, Vector2Int> HasSwipe = new UnityEvent<Cell, Vector2Int>();

    [SerializeField]
    private GraphicRaycaster _graphicRaycaster;
    [SerializeField]
    private EventSystem _eventSystem;
    [SerializeField]
    private float _swipeThreshold;

    private Vector2 _startSwipePosition;
    private Cell _cell;

    private void Update()
    {
        if(Input.touchCount != 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                TouchBegan(touch);
            }
            else if(touch.phase == TouchPhase.Moved)
            {
                CheckSwipe(touch);
            }
            else if(touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
            {
                TouchEnded(touch);
            }
        }
    }

    private void TouchBegan(Touch touch)
    {
        _startSwipePosition = touch.position;
        List<RaycastResult> result = new List<RaycastResult>();
        _graphicRaycaster.Raycast(new PointerEventData(_eventSystem), result);
        foreach(var item in result)
        {
            _cell = item.gameObject.GetComponent<Cell>();
            if(_cell != null)
            {
                return;
            }
        }
    }

    private void TouchEnded(Touch touch)
    {
        _cell = null;
    }

    private void CheckSwipe(Touch touch)
    {
        if(_cell == null)
        {
            return;
        }
        Vector2 swipeDirection = touch.position - _startSwipePosition;
        if(swipeDirection.sqrMagnitude < _swipeThreshold * _swipeThreshold)
        {
            return;
        }
        HasSwipe?.Invoke(_cell, GetDirection(swipeDirection));
        _cell = null;
    }

    private Vector2Int GetDirection(Vector2 vector)
    {
        if(vector == Vector2.zero)
        {
            return Vector2Int.zero;
        }
        if(Mathf.Abs(vector.x) >= Mathf.Abs(vector.y))
        {
            return vector.x < 0 ? Vector2Int.left : Vector2Int.right;
        }
        else
        {
            return vector.y < 0 ? Vector2Int.down : Vector2Int.up;
        }
    }
}
