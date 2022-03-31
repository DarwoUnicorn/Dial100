using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputSwipeInterpreter : InputInterpreter, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private UnityEvent<Cell, Vector2Int> HasSwipe = new UnityEvent<Cell, Vector2Int>();

    [SerializeField]
    private float _swipeThreshold;

    private Vector2 _startSwipePosition;
    private Cell _cell;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startSwipePosition = eventData.position;
        List<RaycastResult> result = new List<RaycastResult>();
        _graphicRaycaster.Raycast(eventData, result);
        foreach(var item in result)
        {
            _cell = item.gameObject.GetComponentInChildren<Cell>();
            if(_cell != null)
            {
                return;
            }
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if(_cell == null)
        {
            return;
        }
        Vector2 swipeDirection = eventData.position - _startSwipePosition;
        if(swipeDirection.sqrMagnitude < _swipeThreshold * _swipeThreshold)
        {
            return;
        }
        HasSwipe?.Invoke(_cell, GetDirection(swipeDirection));
        _cell = null;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
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