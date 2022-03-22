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

    private List<Vector2> _startSwipePosition = new List<Vector2>();
    private List<Cell> _cells = new List<Cell>();

    private void Update()
    {
        if(Input.touchCount != 0)
        {
            Touch touch;
            for(int i = 0; i < Input.touchCount; i++)
            {
                touch = Input.GetTouch(i);
                if(touch.phase == TouchPhase.Began)
                {
                    TouchBegan(touch);
                }
                else if(touch.phase == TouchPhase.Moved)
                {
                    CheckSwipe(touch, i);
                }
                else if(touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
                {
                    TouchEnded(touch, i);
                }
            }
        }
    }

    private void TouchBegan(Touch touch)
    {
        _startSwipePosition.Add(touch.position);
        List<RaycastResult> result = new List<RaycastResult>();
        _graphicRaycaster.Raycast(new PointerEventData(_eventSystem), result);
        Cell temp;
        foreach(var item in result)
        {
            temp = item.gameObject.GetComponent<Cell>();
            if(temp != null)
            {
                _cells.Add(temp);
                return;
            }
        }
        _cells.Add(null);
    }

    private void TouchEnded(Touch touch, int index)
    {
        _startSwipePosition.RemoveAt(index);
        _cells.RemoveAt(index);
    }

    private void CheckSwipe(Touch touch, int index)
    {
        if(_cells[index] == null)
        {
            return;
        }
        Vector2 swipeDirection = touch.position - _startSwipePosition[index];
        if(swipeDirection.sqrMagnitude < _swipeThreshold * _swipeThreshold)
        {
            return;
        }
        HasSwipe?.Invoke(_cells[index], GetDirection(swipeDirection));
        _cells[index] = null;
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
